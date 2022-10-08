using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Wallet;
using CryptoPunks.MoreTech.CryptoClient;
using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Wallet.GetBalance;

public class GetBalanceHandler : IRequestHandler<GetBalanceWalletCommand, GetBalanceWalletResponse>
{
    private readonly IWalletRepository _repository;
    private readonly CryptoWallet _cryptoWallet;

    public GetBalanceHandler(IWalletRepository repository, IHttpClientFactory factory)
    {
        _repository = repository;
        _cryptoWallet = new CryptoWallet(factory);
    }

    public async Task<GetBalanceWalletResponse> Handle(GetBalanceWalletCommand request, CancellationToken cancellationToken)
    {
        var balance = await _cryptoWallet.BalanceGetAsync(request.WalletPublicKey);
        return new(balance!.MaticAmount, balance.CoinsAmount);
    }
}
