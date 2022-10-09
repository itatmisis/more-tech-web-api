namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.Wallet;

public interface IWalletRepository
{
    Task<WalletDb> GetWalletByUserIdAsync(long userId, CancellationToken cancellationToken);

    Task<WalletDb> GetWalletByPublicKeyAsync(string publicKey, CancellationToken cancellationToken);

    Task<long> AddWalletAsync(WalletDb walletDb, CancellationToken cancellationToken);
}
