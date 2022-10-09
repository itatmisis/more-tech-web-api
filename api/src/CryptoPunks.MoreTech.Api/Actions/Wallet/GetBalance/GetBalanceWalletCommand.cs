using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Wallet.GetBalance;

public record GetBalanceWalletCommand(long UserId) : IRequest<GetBalanceWalletResponse>;
