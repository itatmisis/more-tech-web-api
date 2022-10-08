using CryptoPunks.MoreTech.Platform.Data.Providers;
using Dapper;

namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.Wallet;

public class WalletRepository : IWalletRepository
{
    private readonly IDbConnectionsProvider _connectionsProvider;
    private readonly IDbTransactionsProvider _dbTransactionsProvider;

    public WalletRepository(IDbConnectionsProvider connectionsProvider, IDbTransactionsProvider dbTransactionsProvider)
    {
        _connectionsProvider = connectionsProvider;
        _dbTransactionsProvider = dbTransactionsProvider;
    }

    public async Task<WalletDb> GetWalletByUserIdAsync(long userId, CancellationToken cancellationToken)
    {
        const string query =
            @"select w.id, owner,
                     public_key, private_key
              from wallets w where w.owner = :UserId";

        await using var connection = _connectionsProvider.GetConnection();
        var param = new
        {
            UserId = userId
        };
        var result = await connection.QueryFirstOrDefaultAsync<WalletDb>(query, param, _dbTransactionsProvider.Current);
        return result;
    }

    public async Task<long> AddWalletAsync(WalletDb walletDb, CancellationToken cancellationToken)
    {
        const string query =
            @"insert into wallets (owner,
                     public_key, private_key)
               values (:Owner, :PublicKey, :PrivateKey)
               returning id";

        await using var connection = _connectionsProvider.GetConnection();
        var result = await connection.QueryFirstAsync<long>(query, walletDb, _dbTransactionsProvider.Current);
        return result;
    }
}
