namespace CryptoPunks.MoreTech.CryptoClient.Models.Requests;

public class RequestTransferNft
{
    public RequestTransferNft(string fromPrivateKey, string toPublicKey, int tokenId)
    {
        FromPrivateKey = fromPrivateKey;
        ToPublicKey = toPublicKey;
        TokenId = tokenId;
    }

    public string FromPrivateKey { get; set; }

    public string ToPublicKey { get; set; }

    public long TokenId { get; set; }
}
