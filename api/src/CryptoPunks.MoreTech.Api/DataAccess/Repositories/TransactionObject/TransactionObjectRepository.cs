using CryptoPunks.MoreTech.Platform.Data.Providers;
using Dapper;

namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.TransactionObject;

public class TransactionObjectRepository : ITransactionObjectRepository
{
    private readonly IDbConnectionsProvider _connectionsProvider;
    private readonly IDbTransactionsProvider _dbTransactionsProvider;

    public TransactionObjectRepository(IDbConnectionsProvider connectionsProvider, IDbTransactionsProvider dbTransactionsProvider)
    {
        _connectionsProvider = connectionsProvider;
        _dbTransactionsProvider = dbTransactionsProvider;
    }

    public async Task<TransactionObjectDb> GetTransactionObjectAsync(long transactionObjectId, CancellationToken cancellationToken)
    {
        const string query =
            @"select t.id, descriminator,
                     digital_rub_value, matic_value, token_id
              from transactional_objects t where t.id = :TransactionObjectId";

        var connection = _connectionsProvider.GetConnection();
        var param = new
        {
            TransactionObjectId = transactionObjectId
        };
        var result = await connection.QueryFirstOrDefaultAsync<TransactionObjectDb>(query, param, _dbTransactionsProvider.Current);
        return result;
    }

    public async Task<long> AddTransactionObjectAsync(TransactionObjectDb transactionObjectDb, CancellationToken cancellationToken)
    {
        const string query =
            @"insert into transactional_objects (descriminator,
                     digital_rub_value, matic_value, token_id)
               values (:Descriminator, :DigitalRubValue, :MaticValue, :TokenId)
               returning id";

        var connection = _connectionsProvider.GetConnection();
        var param = new
        {
            Descriminator = transactionObjectDb.Descriminator.ToString(),
            transactionObjectDb.DigitalRubValue,
            transactionObjectDb.MaticValue,
            transactionObjectDb.TokenId
        };
        var result = await connection.QueryFirstAsync<long>(query, param, _dbTransactionsProvider.Current);
        return result;
    }

    public async Task DeleteTransactionObjectAsync(long transactionObjectId, CancellationToken cancellationToken)
    {
        const string query = @"delete from transactional_objects t where t.id = :TransactionObjectId";

        var connection = _connectionsProvider.GetConnection();
        var param = new
        {
            TransactionObjectId = transactionObjectId
        };
        await connection.ExecuteAsync(query, param, _dbTransactionsProvider.Current);
    }
}
