using System.Text.Json.Serialization;

namespace CryptoPunks.MoreTech.CryptoClient.Models.Responses;

public class ResponseListGenerateNft
{
    [JsonPropertyName("wallet_id")]
    public string WalletId { get; set; } = null!;

    public IEnumerable<long> Tokens { get; set; } = null!;
}
