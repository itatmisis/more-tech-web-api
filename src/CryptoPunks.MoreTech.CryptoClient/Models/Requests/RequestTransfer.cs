namespace CryptoPunks.MoreTech.CryptoClient.Models.Requests;

public class RequestTransfer
{
    public RequestTransfer(string fromPrivateKey, string toPublicKey, double amount)
    {
        FromPrivateKey = fromPrivateKey;
        ToPublicKey = toPublicKey;
        Amount = amount;
    }

    public string FromPrivateKey { get; set; }

    public string ToPublicKey { get; set; }

    public double Amount { get; set; }
}
