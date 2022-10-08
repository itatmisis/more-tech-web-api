using System.Reflection;
using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Transaction;
using CryptoPunks.MoreTech.Api.DataAccess.Repositories.TransactionObject;
using CryptoPunks.MoreTech.Api.DataAccess.Repositories.User;
using CryptoPunks.MoreTech.Platform.Data.Extensions;
using CryptoPunks.MoreTech.Platform.Data.FluentMigrator;
using Dapper;

namespace CryptoPunks.MoreTech.Api.DataAccess.Extensions;

public static class DataAccessExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;
        services.AddPostgres();
        services.AddMigrator(Assembly.GetExecutingAssembly());
        services.AddRepositories();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ITransactionRepository, TransactionRepository>()
            .AddScoped<ITransactionObjectRepository, TransactionObjectRepository>();
}
