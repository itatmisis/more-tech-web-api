namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.Nft;

public class NftIndexDb
{
    public string Url { get; init; } = null!;

    public long TokenId { get; init; }

    public decimal Price { get; init; }
}
