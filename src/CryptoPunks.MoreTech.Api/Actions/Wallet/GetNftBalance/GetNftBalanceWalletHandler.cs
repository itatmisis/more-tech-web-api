using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Wallet;
using CryptoPunks.MoreTech.CryptoClient;
using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Wallet.GetNftBalance;

public class GetNftBalanceHandler : IRequestHandler<GetNftBalanceWalletCommand, GetNftBalanceWalletResponse>
{
    private readonly IWalletRepository _repository;
    private readonly CryptoWallet _cryptoWallet;

    public GetNftBalanceHandler(IWalletRepository repository, IHttpClientFactory factory)
    {
        _repository = repository;
        _cryptoWallet = new CryptoWallet(factory);
    }

    public async Task<GetNftBalanceWalletResponse> Handle(GetNftBalanceWalletCommand request, CancellationToken cancellationToken)
    {
        var balance = await _cryptoWallet.BalanceNftGetAsync(request.WalletPublicKey);
        return new(balance!.Url, balance!.Tokens);
    }
}
