using CryptoPunks.MoreTech.Platform.Data.Providers;
using Dapper;

namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.Quest;

public class QuestRepository : IQuestRepository
{
    private readonly IDbConnectionsProvider _dbConnectionsProvider;
    private readonly IDbTransactionsProvider _dbTransactionsProvider;

    public QuestRepository(IDbConnectionsProvider dbConnectionsProvider, IDbTransactionsProvider dbTransactionsProvider)
    {
        _dbConnectionsProvider = dbConnectionsProvider;
        _dbTransactionsProvider = dbTransactionsProvider;
    }

    public async Task AddQuestAsync(QuestDb questDb, CancellationToken cancellationToken)
    {
        const string query = @"insert into quests (name, task_description, reward, created_by) values
                                                 (:Name, :TaskDescription, :Reward, :CreatedBy);";

        var connection = _dbConnectionsProvider.GetConnection();
        await connection.ExecuteAsync(query, questDb, _dbTransactionsProvider.Current);
    }

    public async Task<IReadOnlyCollection<QuestDb>> GetQuestsAsync(CancellationToken cancellationToken)
    {
        const string query = @"select id, name, task_description, reward, created_by from quests";

        var connection = _dbConnectionsProvider.GetConnection();
        return (await connection.QueryAsync<QuestDb>(query, transaction: _dbTransactionsProvider.Current)).ToArray();
    }
}
