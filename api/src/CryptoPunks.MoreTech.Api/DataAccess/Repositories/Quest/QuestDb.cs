namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.Quest;

public class QuestDb
{
    public long? Id { get; init; }

    public string Name { get; init; } = null!;

    public string TaskDescription { get; init; } = null!;

    public decimal Reward { get; init; }

    public long CreatedBy { get; init; }
}
