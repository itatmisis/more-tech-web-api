namespace CryptoPunks.MoreTech.CryptoClient.Models.Responses;

public class ResponseBalanceNft
{
    public IEnumerable<BalanceNft> Balance { get; init; } = Array.Empty<BalanceNft>();
}

public class BalanceNft
{
    public string Uri { get; set; } = null!;

    public IEnumerable<long> Tokens { get; set; } = null!;
}
