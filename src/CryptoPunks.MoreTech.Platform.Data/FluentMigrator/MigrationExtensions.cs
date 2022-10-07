using System.Reflection;
using CryptoPunks.MoreTech.Platform.Data.Factories;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoPunks.MoreTech.Platform.Data.FluentMigrator;

public static class MigrationExtension
{
    public static IServiceCollection AddMigrator(this IServiceCollection services, Assembly assembly)
    {
        var servicesProvider = services.BuildServiceProvider();
        var connectionString =
            servicesProvider.GetService<IPostgresConnectionFactory>()?.GetConnection().ConnectionString;

        return services.AddFluentMigratorCore()
            .ConfigureRunner(
                x
                    => x.AddPostgres()
                        .WithGlobalConnectionString(connectionString)
                        .ScanIn(assembly).For.Migrations())
            .AddLogging(y => y.AddFluentMigratorConsole());
    }

    public static Task RunOrMigrateAsync(this WebApplication app, string[] args)
    {
        if (!args.Contains("migrate"))
            return app.RunAsync();
        var iapp = (IApplicationBuilder)app;
        using var scope = iapp.ApplicationServices.CreateScope();
        var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
        runner!.ListMigrations();
        runner.MigrateUp();
        return Task.CompletedTask;
    }
}
