using CryptoPunks.MoreTech.Api.Dtos.UserModels;

namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.User;

public interface IUserRepository
{
    Task<UserDb> GetUserAsync(long userId, CancellationToken cancellationToken);

    Task<JobTitle> GetJobTitleAsync(long titleId, CancellationToken cancellationToken);

    Task<Role> GetRoleAsync(string roleId, CancellationToken cancellationToken);

    Task<long> AddUserAsync(UserDb userDb, CancellationToken cancellationToken);
}
