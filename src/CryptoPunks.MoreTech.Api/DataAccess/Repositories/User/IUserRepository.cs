namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.User;

public interface IUserRepository
{
    Task<UserDb> GetUserAsync(long userId, CancellationToken cancellationToken);

    Task<long> AddUserAsync(UserDb userDb, CancellationToken cancellationToken);
}
