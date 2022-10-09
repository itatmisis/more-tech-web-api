using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Activity.Add;

public record AddQuestCommand(string Name, string Task, decimal Reward, long Creator) : IRequest;
