namespace CryptoPunks.MoreTech.CryptoClient.Models.Requests;

public class RequestHistory
{
    public RequestHistory(int page, int offSet, string sort)
    {
        Page = page;
        OffSet = offSet;
        Sort = sort;
    }

    public int Page { get; set; }

    public int OffSet { get; set; }

    public string Sort { get; set; }
}
