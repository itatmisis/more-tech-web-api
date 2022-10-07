namespace CryptoPunks.MoreTech.CryptoClient.Models.Responses;

public class ResponseHistoryItem
{
    public int BlockNumber { get; set; }

    public int TimeStamp { get; set; }

    public string ContractAddress { get; set; } = null!;

    public string From { get; set; } = null!;

    public string To { get; set; } = null!;

    public string TokenName { get; set; } = null!;

    public string TokenSymbol { get; set; } = null!;

    public int GasUsed { get; set; }

    public int Confirmations { get; set; }
}
