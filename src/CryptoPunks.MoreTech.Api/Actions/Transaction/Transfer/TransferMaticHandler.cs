using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Transaction;
using CryptoPunks.MoreTech.Api.DataAccess.Repositories.TransactionObject;
using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Wallet;
using CryptoPunks.MoreTech.CryptoClient;
using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Transaction.Transfer;

public class TransferMaticHandler : IRequestHandler<TransferMaticCommand, TransferResponse>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionObjectRepository _transactionObjectRepository;
    private readonly IWalletRepository _walletRepository;
    private readonly CryptoWallet _cryptoWallet;

    public TransferMaticHandler(CryptoWallet cryptoWallet, ITransactionRepository transactionRepository, ITransactionObjectRepository transactionObjectRepository, IWalletRepository walletRepository)
    {
        _transactionRepository = transactionRepository;
        _transactionObjectRepository = transactionObjectRepository;
        _walletRepository = walletRepository;
        _cryptoWallet = cryptoWallet;
    }

    public async Task<TransferResponse> Handle(TransferMaticCommand request, CancellationToken cancellationToken)
    {
        var transactionObjectId = await _transactionObjectRepository.AddTransactionObjectAsync(
            new()
            {
                Descriminator = TokenType.Matic,
                MaticValue = (decimal)request.Amount
            }, cancellationToken);

        var fromWallet = await _walletRepository.GetWalletByUserIdAsync(request.FromUser, cancellationToken);
        var toWallet = await _walletRepository.GetWalletByUserIdAsync(request.ToUser, cancellationToken);

        var transferResult = await _cryptoWallet.TransferMaticPostAsync(new(
            fromWallet.PrivateKey,
            toWallet.PublicKey,
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
