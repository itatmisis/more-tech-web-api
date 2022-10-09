using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Activity.Get;

public record GetQuestCommand() : IRequest<GetQuestsResponse>;
