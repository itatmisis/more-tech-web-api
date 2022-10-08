using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Wallet.Add;

public record AddWalletCommand(long UserId) : IRequest<AddWalletResponse>;
