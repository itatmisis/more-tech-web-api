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

        services.AddHttpClient(nameof(CryptoClient.CryptoWallet), c => c.BaseAddress = new("https://hackathon.lsp.team/hk/v1/"));
        return services;
    }
}
