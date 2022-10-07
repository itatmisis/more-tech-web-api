using CryptoPunks.MoreTech.Platform.Data.Providers;
using Dapper;

namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.User;

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionsProvider _connectionsProvider;
    private readonly IDbTransactionsProvider _dbTransactionsProvider;

    public UserRepository(IDbConnectionsProvider connectionsProvider, IDbTransactionsProvider dbTransactionsProvider)
    {
        _connectionsProvider = connectionsProvider;
        _dbTransactionsProvider = dbTransactionsProvider;
    }

    public async Task<UserDb> GetUserAsync(long userId, CancellationToken cancellationToken)
    {
        const string query =
            @"select u.id, nickname,
                     role, profile_pic_url,
                     first_name, second_name,
                     middle_name, job_title,
                     employer, created_at
              from users u where u.id = :UserId";

        await using var connection = _connectionsProvider.GetConnection();
        await using var transaction = _dbTransactionsProvider.Current;
        var param = new
        {
            UserId = userId
        };
        var result = await connection.QueryFirstOrDefaultAsync<UserDb>(query, param, transaction);
        return result;
    }

    public async Task<long> AddUserAsync(UserDb userDb, CancellationToken cancellationToken)
    {
        const string query =
            @"insert into users (nickname,
                     role, profile_pic_url,
                     first_name, second_name,
                     middle_name, job_title,
                     employer)
               values (:Nickname, :Role, :ProfilePicUrl, :FirstName, :SecondName, :MiddleName, :JobTitle, :Employer)
               returning id";

        // var param = new
        // {
        //     userDb.Nickname,
        //     userDb.Role,
        //     userDb.ProfilePicUrl,
        //     userDb.FirstName,
        //     userDb.SecondName,
        //     userDb.MiddleName,
        //     userDb.JobTitle,
        //     userDb.Employer
        // };
        await using var connection = _connectionsProvider.GetConnection();
        await using var transaction = _dbTransactionsProvider.Current;
        var result = await connection.QueryFirstAsync<long>(query, userDb, transaction);
        return result;
    }
}