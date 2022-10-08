using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Wallet.GetBalance;

public record GetBalanceWalletCommand(string WalletPublicKey) : IRequest<GetBalanceWalletResponse>;
