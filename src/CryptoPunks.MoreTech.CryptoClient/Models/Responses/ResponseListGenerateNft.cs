using System.Text.Json.Serialization;

namespace CryptoPunks.MoreTech.CryptoClient.Models.Responses;

public class ResponseListGenerateNft
{
    [JsonPropertyName("wallet_id")]
    public string WalletId { get; set; } = null!;

    public IEnumerable<int> Tokens { get; set; } = null!;
}
