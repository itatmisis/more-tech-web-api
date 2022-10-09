using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Nft.Get;

public record GetNftsCommand(long UserId) : IRequest<GetNftsResponse>;
