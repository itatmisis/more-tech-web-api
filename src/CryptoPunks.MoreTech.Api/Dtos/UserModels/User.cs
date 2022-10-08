namespace CryptoPunks.MoreTech.Api.Dtos.UserModels;

public class User
{
    public long Id { get; init; }

    public string Nickname { get; init; } = null!;

    public Role Role { get; init; } = null!;

    public string? ProfilePicUrl { get; init; }

    public string FirstName { get; init; } = null!;

    public string SecondName { get; init; } = null!;

    public string? MiddleName { get; init; }

    public JobTitle JobTitle { get; init; } = null!;

    public long? EmployerId { get; init; } = null!;

    public int Points { get; init; }

    public int Levels { get; init; }
}
