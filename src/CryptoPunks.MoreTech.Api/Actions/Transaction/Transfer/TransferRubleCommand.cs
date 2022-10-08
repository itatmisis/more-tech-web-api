using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Transaction.Transfer;

public record TransferRubleCommand(string FromPrivateKey, string ToPublicKey, double Amount) : IRequest<TransferResponse>;
