namespace CryptoPunks.MoreTech.CryptoClient.Models.Responses;

public class ResponseBalanceNft
{
    public IEnumerable<BalanceNft> BalanceNfts { get; init; } = Array.Empty<BalanceNft>();
}

public class BalanceNft
{
    public string Url { get; set; } = null!;

    public IEnumerable<long> Tokens { get; set; } = null!;
}
