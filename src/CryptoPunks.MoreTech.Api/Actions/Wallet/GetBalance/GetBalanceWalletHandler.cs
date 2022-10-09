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
        var publicKey = (await _repository.GetWalletByUserIdAsync(request.UserId, cancellationToken)).PublicKey;
        var balance = await _cryptoWallet.BalanceGetAsync(publicKey);
        return new(balance!.MaticAmount, balance.CoinsAmount);
    }
}
