using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Wallet.GetNftBalance;

public record GetNftBalanceWalletCommand(string WalletPublicKey) : IRequest<GetNftBalanceWalletResponse>;
