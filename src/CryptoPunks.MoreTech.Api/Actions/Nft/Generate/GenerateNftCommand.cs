using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Nft.Generate;

public record GenerateNftCommand(string Url, int Count, decimal Price, long UserId) : IRequest;
