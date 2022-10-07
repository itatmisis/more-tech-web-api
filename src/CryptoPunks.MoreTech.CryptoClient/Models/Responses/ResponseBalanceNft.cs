namespace CryptoPunks.MoreTech.CryptoClient.Models.Responses;

public class ResponseBalanceNft
{
    public string Url { get; set; } = null!;

    public IEnumerable<int> Tokens { get; set; } = null!;
}
