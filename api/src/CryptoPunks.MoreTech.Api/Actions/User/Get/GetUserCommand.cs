using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.User.Get;

public record GetUserCommand(long Id) : IRequest<GetUserResponse>;
