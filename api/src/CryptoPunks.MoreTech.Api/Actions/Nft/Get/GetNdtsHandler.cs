using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Nft;
using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Wallet;
using CryptoPunks.MoreTech.Api.Dtos.NftModels;
using CryptoPunks.MoreTech.CryptoClient;
using JetBrains.Annotations;
using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Nft.Get;

[UsedImplicitly]
public class GetNdtsHandler : IRequestHandler<GetNftsCommand, GetNftsResponse>
{
    private readonly INftIndexRepository _repository;
    private readonly IWalletRepository _walletRepository;
    private readonly CryptoWallet _cryptoWallet;

    public GetNdtsHandler(INftIndexRepository repository, CryptoWallet cryptoWallet, IWalletRepository walletRepository)
    {
        _repository = repository;
        _cryptoWallet = cryptoWallet;
        _walletRepository = walletRepository;
    }

    public async Task<GetNftsResponse> Handle(GetNftsCommand request, CancellationToken cancellationToken)
    {
        var publicKey = (await _walletRepository.GetWalletByUserIdAsync(request.UserId, cancellationToken)).PublicKey;
        var nftBalanceResponse = await _cryptoWallet.BalanceNftGetAsync(publicKey);
        var urls = nftBalanceResponse?.Balance.Select(x => x.Uri);
        if (urls is null)
            return new GetNftsResponse(Array.Empty<NftToken>());
        var indexes = await _repository.GetNtfIndexAsync(urls.ToArray(), cancellationToken);
        var result = indexes.Select(nftIndexDb => new NftToken(nftIndexDb.Url, nftIndexDb.TokenId, nftIndexDb.Price))
            .ToList();
        return new GetNftsResponse(result);
    }
}
