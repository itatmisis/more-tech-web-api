using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Transaction.Get;

public record GetTransactionsCommand(long UserId) : IRequest<GetTransactionsResponse>;
