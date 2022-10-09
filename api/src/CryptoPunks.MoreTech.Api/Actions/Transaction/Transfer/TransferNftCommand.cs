using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Transaction.Transfer;

public record TransferNftCommand(long FromUser, long ToUser, long TokenId) : IRequest<TransferResponse>;
