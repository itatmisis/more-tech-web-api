namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.Quest;

public interface IQuestRepository
{
    Task AddQuestAsync(QuestDb questDb, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<QuestDb>> GetQuestsAsync(CancellationToken cancellationToken);
}
