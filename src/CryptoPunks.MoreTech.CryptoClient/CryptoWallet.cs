using System.Net.Http.Json;
using CryptoPunks.MoreTech.CryptoClient.Models.Requests;
using CryptoPunks.MoreTech.CryptoClient.Models.Responses;

namespace CryptoPunks.MoreTech.CryptoClient;

public static class CryptoWallet
{
    public static async Task<ResponseNewWallet?> NewWalletPostAsync()
    {
        var httpResponseMessage = await CryptoHttpClient.Client.PostAsync("wallets/new", null);
        return await httpResponseMessage.Content.ReadFromJsonAsync<ResponseNewWallet>();
    }

    public static async Task<ResponseTransaction?> TransferMaticPostAsync(RequestTransfer request)
    {
        var httpResponseMessage = await CryptoHttpClient.Client.PostAsJsonAsync("transfers/matic", request);
        return await httpResponseMessage.Content.ReadFromJsonAsync<ResponseTransaction>();
    }

    public static async Task<ResponseTransaction?> TransferRublePostAsync(RequestTransfer request)
    {
        var httpResponseMessage = await CryptoHttpClient.Client.PostAsJsonAsync("transfers/ruble", request);
        return await httpResponseMessage.Content.ReadFromJsonAsync<ResponseTransaction>();
    }

    public static async Task<ResponseTransaction?> TransferNftPostAsync(RequestTransferNft request)
    {
        var httpResponseMessage = await CryptoHttpClient.Client.PostAsJsonAsync("transfers/nft", request);
        return await httpResponseMessage.Content.ReadFromJsonAsync<ResponseTransaction>();
    }

    public static async Task<ResponseTransfersStatus?> TransferStatusGetAsync(string transactionHash) =>
        await CryptoHttpClient.Client.GetFromJsonAsync<ResponseTransfersStatus>($"transfers/status/{transactionHash}");

    public static async Task<ResponseBalance?> BalanceGetAsync(string publicKey) =>
        await CryptoHttpClient.Client.GetFromJsonAsync<ResponseBalance>($"wallets/{publicKey}/balance");

    public static async Task<ResponseBalanceNft?> BalanceNftGetAsync(string publicKey) =>
        await CryptoHttpClient.Client.GetFromJsonAsync<ResponseBalanceNft>($"wallets/{publicKey}/nft/balance");

    public static async Task<ResponseTransaction?> GenerateNftPostAsync(RequestGenerateNft request)
    {
        var httpResponseMessage = await CryptoHttpClient.Client.PostAsJsonAsync("nft/generate", request);
        return await httpResponseMessage.Content.ReadFromJsonAsync<ResponseTransaction>();
    }

    public static async Task<ResponseInformationNft?> InformationNftGetAsync(string tokenId) =>
        await CryptoHttpClient.Client.GetFromJsonAsync<ResponseInformationNft>($"nft/{tokenId}");

    public static async Task<ResponseListGenerateNft?> ListGenerateNftGetAsync(string transactionHash) =>
        await CryptoHttpClient.Client.GetFromJsonAsync<ResponseListGenerateNft>($"nft/generate/{transactionHash}");

    public static async Task<ResponseHistory?> HistoryPostAsync(RequestHistory request, string publicKey)
    {
        var httpResponseMessage = await CryptoHttpClient.Client.PostAsJsonAsync($"wallets/{publicKey}/history", request);
        return await httpResponseMessage.Content.ReadFromJsonAsync<ResponseHistory>();
    }
}
