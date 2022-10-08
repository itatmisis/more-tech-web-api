using CryptoPunks.MoreTech.Api.Dtos;

namespace CryptoPunks.MoreTech.Api.CryptoWalletIntegration.Extensions;

public static class CryptoWalletIntegrationExtensions
{
    public static IServiceCollection AddCryptoWalletIntegration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var optionsFromConf = configuration
            .GetSection(nameof(CryptoWalletCredentials))
            .Get<CryptoWalletCredentials>();

        var privateKey = configuration["CW_PRIVATE_KEY"];
        var publicKey = configuration["CW_PUBLIC_KEY"];
        var options = new CryptoWalletCredentials
        {
            PrivateKey = privateKey ?? optionsFromConf?.PrivateKey ?? string.Empty,
            PublicKey = publicKey ?? optionsFromConf?.PrivateKey ?? string.Empty
        };
        // TODO: Вынести сюда создание http клиента
        services.AddSingleton(options);
        return services;
    }
}
