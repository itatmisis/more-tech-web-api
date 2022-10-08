using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Nft.Generate;

public class GenerateNtfHandler : IRequestHandler<GenerateNftCommand, GenerateNftResponse>
{
    public Task<GenerateNftResponse> Handle(GenerateNftCommand request, CancellationToken cancellationToken)
    {

    }
}
