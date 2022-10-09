using CryptoPunks.MoreTech.Api.Dtos.NftModels;

namespace CryptoPunks.MoreTech.Api.Actions.Nft.Get;

public record GetNftsResponse(IEnumerable<NftToken> Tokens);
