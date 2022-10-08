namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.Transaction;

public class TransactionDb
{
    public long? Id { get; init; }

    public long TransactionObjectId { get; init; }

    public long? From { get; init; }

    public long To { get; init; }

    public string Hash { get; init; } = null!;

    public DateTime CreatedAt { get; init; }
}
