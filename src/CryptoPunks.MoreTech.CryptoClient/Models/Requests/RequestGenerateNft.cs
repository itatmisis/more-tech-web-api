namespace CryptoPunks.MoreTech.CryptoClient.Models.Requests;

public class RequestGenerateNft
{
    public RequestGenerateNft(string toPublicKey, string uri, int nftCount)
    {
        ToPublicKey = toPublicKey;
        Uri = uri;
        NftCount = nftCount;
    }

    public string ToPublicKey { get; set; }

    public string Uri { get; set; }

    public int NftCount { get; set; }
}
