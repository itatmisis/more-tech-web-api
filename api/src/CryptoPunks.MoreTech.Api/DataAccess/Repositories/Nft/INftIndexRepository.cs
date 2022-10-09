namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.Nft;

public interface INftIndexRepository
{
    Task AddNftIndexesAsync(IReadOnlyCollection<NftIndexDb> indexDb, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<NftIndexDb>> GetNtfIndexAsync(IReadOnlyCollection<string> nftUrls, CancellationToken cancellationToken);
}
