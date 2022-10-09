namespace CryptoPunks.MoreTech.Api.DataAccess.Repositories.User;

public class UserDb
{
    public long? Id { get; init; }

    public string Nickname { get; init; } = null!;

    public string Role { get; init; } = null!;

    public string? ProfilePicUrl { get; init; }

    public string FirstName { get; init; } = null!;

    public string SecondName { get; init; } = null!;

    public string? MiddleName { get; init; }

    public long JobTitle { get; init; }

    public long? Employer { get; init; }

    public DateTime CreatedAt { get; init; }

    public int Level { get; init; }

    public int Points { get; init; }
}
