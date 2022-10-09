using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Transaction.Transfer;

public record TransferMaticCommand(long FromUser, long ToUser, double Amount) : IRequest<TransferResponse>;
