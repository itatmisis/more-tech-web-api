using CryptoPunks.MoreTech.Api.DataAccess.Repositories.User;
using JetBrains.Annotations;
using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.User.Add;

[UsedImplicitly]
public class AddUserHandler : IRequestHandler<AddUserCommand, AddUserResponse>
{
    private readonly IUserRepository _repository;

    public AddUserHandler(IUserRepository repository)
        => _repository = repository;

    public async Task<AddUserResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = new UserDb
        {
            Nickname = request.Nickname,
            Role = request.Role,
            Employer = request.Employer,
            SecondName = request.SecondName,
            MiddleName = request.MiddleName,
            FirstName = request.FirstName,
            ProfilePicUrl = request.ProfilePicUrl,
            JobTitle = request.JobTitle
        };

        var result = await _repository.AddUserAsync(dbUser, cancellationToken);
        return new AddUserResponse(result);
    }
}
