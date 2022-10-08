namespace CryptoPunks.MoreTech.Api.Actions.Wallet.GetNftBalance;

public record GetNftBalanceWalletResponse(string Url, IEnumerable<long> Tokens);
