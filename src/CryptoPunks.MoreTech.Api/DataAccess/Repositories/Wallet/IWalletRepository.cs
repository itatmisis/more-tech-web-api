namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.Wallet;

public interface IWalletRepository
{
    Task<WalletDb> GetWalletByUserIdAsync(long walletId, CancellationToken cancellationToken);

    Task<long> AddWalletAsync(WalletDb walletDb, CancellationToken cancellationToken);
}
