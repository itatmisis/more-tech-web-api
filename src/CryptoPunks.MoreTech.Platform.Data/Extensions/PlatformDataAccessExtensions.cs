using CryptoPunks.MoreTech.Platform.Data.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoPunks.MoreTech.Platform.Data.Extensions;

public static class DataAccessExtensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services)
        => services.AddScoped<IPostgresConnectionFactory, PostgresConnectionFactory>();
}
