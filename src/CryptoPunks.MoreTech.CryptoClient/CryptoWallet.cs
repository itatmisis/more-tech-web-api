using System.Net.Http.Json;
using CryptoPunks.MoreTech.CryptoClient.Models.Requests;
using CryptoPunks.MoreTech.CryptoClient.Models.Responses;

namespace CryptoPunks.MoreTech.CryptoClient;

public class CryptoWallet
{
    private readonly HttpClient _httpClient;

    public CryptoWallet(IHttpClientFactory factory) => _httpClient = factory.CreateClient(nameof(CryptoWallet));

    public async Task<ResponseNewWallet?> NewWalletPostAsync()
    {
        var httpResponseMessage = await _httpClient.PostAsync("wallets/new", null);
        return await httpResponseMessage.Content.ReadFromJsonAsync<ResponseNewWallet>();
    }

    public async Task<ResponseTransaction?> TransferMaticPostAsync(RequestTransfer request)
    {
        var httpResponseMessage = await _httpClient.PostAsJsonAsync("transfers/matic", request);
        return await httpResponseMessage.Content.ReadFromJsonAsync<ResponseTransaction>();
    }

    public async Task<ResponseTransaction?> TransferRublePostAsync(RequestTransfer request)
    {
        var httpResponseMessage = await _httpClient.PostAsJsonAsync("transfers/ruble", request);
        return await httpResponseMessage.Content.ReadFromJsonAsync<ResponseTransaction>();
    }

    public async Task<ResponseTransaction?> TransferNftPostAsync(RequestTransferNft request)
    {
        var httpResponseMessage = await _httpClient.PostAsJsonAsync("transfers/nft", request);
        return await httpResponseMessage.Content.ReadFromJsonAsync<ResponseTransaction>();
    }

    public async Task<ResponseTransfersStatus?> TransferStatusGetAsync(string transactionHash) =>
        await _httpClient.GetFromJsonAsync<ResponseTransfersStatus>($"transfers/status/{transactionHash}");

    public async Task<ResponseBalance?> BalanceGetAsync(string publicKey) =>
        await _httpClient.GetFromJsonAsync<ResponseBalance>($"wallets/{publicKey}/balance");

    public async Task<ResponseBalanceNft?> BalanceNftGetAsync(string publicKey) =>
        await _httpClient.GetFromJsonAsync<ResponseBalanceNft>($"wallets/{publicKey}/nft/balance");

    public async Task<ResponseTransaction?> GenerateNftPostAsync(RequestGenerateNft request)
    {
        var httpResponseMessage = await _httpClient.PostAsJsonAsync("nft/generate", request);
        return await httpResponseMessage.Content.ReadFromJsonAsync<ResponseTransaction>();
    }

    public async Task<ResponseInformationNft?> InformationNftGetAsync(string tokenId) =>
        await _httpClient.GetFromJsonAsync<ResponseInformationNft>($"nft/{tokenId}");

    public async Task<ResponseListGenerateNft?> ListGenerateNftGetAsync(string transactionHash) =>
        await _httpClient.GetFromJsonAsync<ResponseListGenerateNft>($"nft/generate/{transactionHash}");

    public async Task<ResponseHistory?> HistoryPostAsync(RequestHistory request, string publicKey)
    {
        var httpResponseMessage = await _httpClient.PostAsJsonAsync($"wallets/{publicKey}/history", request);
        return await httpResponseMessage.Content.ReadFromJsonAsync<ResponseHistory>();
    }
}
