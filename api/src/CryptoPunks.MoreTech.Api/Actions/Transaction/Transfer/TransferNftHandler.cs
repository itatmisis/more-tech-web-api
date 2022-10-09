using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Transaction;
using CryptoPunks.MoreTech.Api.DataAccess.Repositories.TransactionObject;
using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Wallet;
using CryptoPunks.MoreTech.CryptoClient;
using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Transaction.Transfer;

public class TransferNftHandler : IRequestHandler<TransferNftCommand, TransferResponse>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionObjectRepository _transactionObjectRepository;
    private readonly IWalletRepository _walletRepository;
    private readonly CryptoWallet _cryptoWallet;

    public TransferNftHandler(CryptoWallet cryptoWallet, ITransactionRepository transactionRepository, ITransactionObjectRepository transactionObjectRepository, IWalletRepository walletRepository)
    {
        _transactionRepository = transactionRepository;
        _transactionObjectRepository = transactionObjectRepository;
        _walletRepository = walletRepository;
        _cryptoWallet = cryptoWallet;
    }

    public async Task<TransferResponse> Handle(TransferNftCommand request, CancellationToken cancellationToken)
    {
        var transactionObjectId = await _transactionObjectRepository.AddTransactionObjectAsync(
            new()
            {
                Descriminator = TokenType.NFT,
                TokenId = request.TokenId
            }, cancellationToken);

        var fromWallet = await _walletRepository.GetWalletByUserIdAsync(request.FromUser, cancellationToken);
        var toWallet = await _walletRepository.GetWalletByUserIdAsync(request.ToUser, cancellationToken);

        var transferResult = await _cryptoWallet.TransferNftPostAsync(new(
            fromWallet.PrivateKey,
            fromWallet.PublicKey,
            request.TokenId));

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
