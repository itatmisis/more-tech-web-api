using CryptoPunks.MoreTech.Platform.Data.Providers;
using Dapper;

namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.Nft;

public class NftIndexRepository : INftIndexRepository
{
    private readonly IDbConnectionsProvider _connectionsProvider;
    private readonly IDbTransactionsProvider _dbTransactionsProvider;

    public NftIndexRepository(
        IDbConnectionsProvider connectionsProvider,
        IDbTransactionsProvider dbTransactionsProvider)
    {
        _connectionsProvider = connectionsProvider;
        _dbTransactionsProvider = dbTransactionsProvider;
    }

    public async Task AddNftIndexesAsync(IReadOnlyCollection<NftIndexDb> indexDb, CancellationToken cancellationToken)
    {
        const string query = @"insert into nft_index (url, token_id, price) values
                                                 (:Url, :TokenId, :Price);";

        var connection = _connectionsProvider.GetConnection();
        await connection.ExecuteAsync(query, indexDb.Select(x => x), _dbTransactionsProvider.Current);
    }

    public async Task<IReadOnlyCollection<NftIndexDb>> GetNtfIndexAsync(IReadOnlyCollection<string> nftUrls, CancellationToken cancellationToken)
    {
        const string query = @"select url, token_id, price from nft_index where url = any(@Urls)";

        var connection = _connectionsProvider.GetConnection();
        var param = new
        {
            Urls = nftUrls
        };
        return (await connection.QueryAsync<NftIndexDb>(query, param, _dbTransactionsProvider.Current)).ToArray();
    }
}
