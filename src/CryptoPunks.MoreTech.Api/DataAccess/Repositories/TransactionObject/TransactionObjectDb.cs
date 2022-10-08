namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.TransactionObject;

public class TransactionObjectDb
{
    public long? Id { get; init; }

    public TokenType Descriminator { get; init; }

    public decimal? DigitalRubValue { get; init; }

    public decimal? MaticValue { get; init; }

    public string? TokenId { get; init; }
}
