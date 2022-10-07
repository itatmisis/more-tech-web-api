namespace CryptoPunks.MoreTech.CryptoClient.Models.Responses;

public class ResponseBalanceNft
{
    public string Url { get; set; } = null!;

    public IEnumerable<long> Tokens { get; set; } = null!;
}
