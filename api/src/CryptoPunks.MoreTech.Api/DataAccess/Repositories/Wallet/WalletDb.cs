namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.Wallet;

public class WalletDb
{
    public long? Id { get; init; }

    public long Owner { get; init; }

    public string PublicKey { get; init; } = null!;

    public string PrivateKey { get; init; } = null!;
}
