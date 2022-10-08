using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Transaction;
using CryptoPunks.MoreTech.Api.DataAccess.Repositories.TransactionObject;
using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Wallet;
using CryptoPunks.MoreTech.CryptoClient;
using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Transaction.Transfer;

public class TransferRubleHandler : IRequestHandler<TransferRubleCommand, TransferResponse>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionObjectRepository _transactionObjectRepository;
    private readonly IWalletRepository _walletRepository;
    private readonly CryptoWallet _cryptoWallet;

    public TransferRubleHandler(IHttpClientFactory factory, ITransactionRepository transactionRepository, ITransactionObjectRepository transactionObjectRepository, IWalletRepository walletRepository)
    {
        _transactionRepository = transactionRepository;
        _transactionObjectRepository = transactionObjectRepository;
        _walletRepository = walletRepository;
        _cryptoWallet = new CryptoWallet(factory);
    }

    public async Task<TransferResponse> Handle(TransferRubleCommand request, CancellationToken cancellationToken)
    {
        var transactionObjectId = await _transactionObjectRepository.AddTransactionObjectAsync(
            new()
            {
                Descriminator = TokenType.Matic,
                DigitalRubValue = (decimal)request.Amount
            }, cancellationToken);

        var fromWallet = await _walletRepository.GetWalletPrivateKeyAsync(request.FromPrivateKey, cancellationToken);
        var toWallet = await _walletRepository.GetWalletByPublicKeyAsync(request.ToPublicKey, cancellationToken);

        var transferResult = await _cryptoWallet.TransferRublePostAsync(new(
            request.FromPrivateKey,
            request.ToPublicKey,
            request.Amount));

        await _transactionRepository.AddTransactionAsync(
            new()
            {
                TransactionObjectId = transactionObjectId,
                From = fromWallet.Owner,
                To = toWallet.Owner,
                Hash = transferResult!.TransactionHash
            }, cancellationToken);

        return new(transferResult.TransactionHash);
    }
}
