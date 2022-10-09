using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Transaction.Transfer;

public record TransferRubleCommand(long FromUser, long ToUser, double Amount) : IRequest<TransferResponse>;
