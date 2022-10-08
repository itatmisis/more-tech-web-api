using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Nft.Generate;

public record GenerateNftCommand(string Url, int Count, long UserId) : IRequest<GenerateNftResponse>;
