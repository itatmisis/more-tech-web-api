using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Wallet;
using CryptoPunks.MoreTech.CryptoClient;
using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Wallet.Add;

public class AddWalletHandler : IRequestHandler<AddWalletCommand, AddWalletResponse>
{
    private readonly IWalletRepository _repository;
    private readonly CryptoWallet _cryptoWallet;

    public AddWalletHandler(IWalletRepository repository, IHttpClientFactory factory)
    {
        _repository = repository;
        _cryptoWallet = new CryptoWallet(factory);
    }

    public async Task<AddWalletResponse> Handle(AddWalletCommand request, CancellationToken cancellationToken)
    {
        var requestClientResult = await _cryptoWallet.NewWalletPostAsync();
        var walletId = await _repository.AddWalletAsync(
            new()
            {
                Owner = request.UserId,
                PublicKey = requestClientResult!.PublicKey,
                PrivateKey = requestClientResult!.PrivateKey
            }, cancellationToken);

        return new(walletId);
    }
}
