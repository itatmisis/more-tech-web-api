using System.Text.Json.Serialization;

namespace CryptoPunks.MoreTech.CryptoClient.Models.Responses;

public class ResponseTransaction
{
    [JsonPropertyName("transaction_hash")]
    public string TransactionHash { get; set; } = null!;
}
