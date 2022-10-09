using CryptoPunks.MoreTech.Platform.Data.Providers;

using Dapper;

namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.Transaction;

public class TransactionRepository : ITransactionRepository
{
    private readonly IDbConnectionsProvider _connectionsProvider;
    private readonly IDbTransactionsProvider _dbTransactionsProvider;

    public TransactionRepository(IDbConnectionsProvider connectionsProvider, IDbTransactionsProvider dbTransactionsProvider)
    {
        _connectionsProvider = connectionsProvider;
        _dbTransactionsProvider = dbTransactionsProvider;
    }

    public async Task<TransactionDb> GetTransactionAsync(long transactionId, CancellationToken cancellationToken)
    {
        const string query =
            @"select t.id, transactional_object,
                     from, to,
                     hash, created_at
              from pending_transactions t where t.id = :TransactionId";

        var connection = _connectionsProvider.GetConnection();
        var param = new
        {
            TransactionId = transactionId
        };
        var result = await connection.QueryFirstOrDefaultAsync<TransactionDb>(query, param, _dbTransactionsProvider.Current);
        return result;
    }

    public async Task<long> AddTransactionAsync(TransactionDb transactionDb, CancellationToken cancellationToken)
    {
        const string query =
            @"insert into pending_transactions (transactional_object,
                     from, to,
                     hash, created_at)
               values (:TransactionObjectId, :From, :To, :Hash, :CreatedAt)
               returning id";

        var connection = _connectionsProvider.GetConnection();
        var result = await connection.QueryFirstAsync<long>(query, transactionDb, _dbTransactionsProvider.Current);
        return result;
    }

    public async Task DeleteTransactionAsync(long transactionId, CancellationToken cancellationToken)
    {
        const string query = @"delete from pending_transactions t where t.id = :TransactionId";

        var connection = _connectionsProvider.GetConnection();
        var param = new
        {
            TransactionId = transactionId
        };
        await connection.ExecuteAsync(query, param, _dbTransactionsProvider.Current);
    }
}
