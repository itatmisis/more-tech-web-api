using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.User.Add;

public record AddUserCommand(
    string Nickname,
    string Role,
    string? ProfilePicUrl,
    string FirstName,
    string SecondName,
    string? MiddleName,
    long JobTitle,
    long? Employer) : IRequest<AddUserResponse>;
