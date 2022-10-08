using CryptoPunks.MoreTech.Api.DataAccess.Repositories.User;
using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.User.Get;

public class GetUserHandler : IRequestHandler<GetUserCommand, GetUserResponse>
{
    private readonly IUserRepository _repository;

    public GetUserHandler(IUserRepository repository)
        => _repository = repository;

    public async Task<GetUserResponse> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        // TODO: Добавить логику обогащения доменной модели
        await Task.Delay(1);
        return new GetUserResponse(new Dtos.User());
    }
}
