using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Transaction.Transfer;

public record TransferMaticCommand(string FromPrivateKey, string ToPublicKey, double Amount) : IRequest<TransferResponse>;
