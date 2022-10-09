using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Quest;
using JetBrains.Annotations;
using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Activity.Get;

[UsedImplicitly]
public class GetQuestsHandler : IRequestHandler<GetQuestCommand, GetQuestsResponse>
{
    private readonly IQuestRepository _questRepository;

    public GetQuestsHandler(IQuestRepository questRepository)
        => _questRepository = questRepository;

    public async Task<GetQuestsResponse> Handle(GetQuestCommand request, CancellationToken cancellationToken)
    {
        var quests = await _questRepository.GetQuestsAsync(cancellationToken);
        return new GetQuestsResponse(quests);
    }
}
