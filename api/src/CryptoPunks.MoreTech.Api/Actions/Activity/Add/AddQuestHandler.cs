using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Quest;
using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Activity.Add;

public class AddQuestHandler : AsyncRequestHandler<AddQuestCommand>
{
    private readonly IQuestRepository _questRepository;

    public AddQuestHandler(IQuestRepository questRepository)
        => _questRepository = questRepository;

    protected override Task Handle(AddQuestCommand request, CancellationToken cancellationToken)
    {
        var questDb = new QuestDb
        {
            Name = request.Name,
            TaskDescription = request.Task,
            CreatedBy = request.Creator,
            Reward = request.Reward
        };

        return _questRepository.AddQuestAsync(questDb, cancellationToken);
    }
}
