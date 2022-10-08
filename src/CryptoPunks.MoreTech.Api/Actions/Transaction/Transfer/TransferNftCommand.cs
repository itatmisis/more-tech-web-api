using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Transaction.Transfer;

public record TransferNftCommand(string FromPrivateKey, string ToPublicKey, long TokenId) : IRequest<TransferResponse>;
