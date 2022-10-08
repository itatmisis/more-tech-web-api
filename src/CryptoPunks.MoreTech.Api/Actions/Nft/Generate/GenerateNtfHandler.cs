using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Nft;
using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Wallet;
using CryptoPunks.MoreTech.CryptoClient;
using CryptoPunks.MoreTech.CryptoClient.Models.Requests;
using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Nft.Generate;

public class GenerateNtfHandler : AsyncRequestHandler<GenerateNftCommand>
{
    private readonly INftIndexRepository _repository;
    private readonly IWalletRepository _walletRepository;
    private readonly CryptoWallet _cryptoWallet;

    public GenerateNtfHandler(
        INftIndexRepository repository,
        CryptoWallet cryptoWallet,
        IWalletRepository walletRepository)
    {
        _repository = repository;
        _cryptoWallet = cryptoWallet;
        _walletRepository = walletRepository;
    }

    protected override async Task Handle(GenerateNftCommand request, CancellationToken cancellationToken)
    {
        var publicKey = (await _walletRepository.GetWalletByUserIdAsync(request.UserId, cancellationToken)).PublicKey;
        var generateRequest = new RequestGenerateNft(publicKey, request.Url, request.Count);
        var generationResponse = await _cryptoWallet.GenerateNftPostAsync(generateRequest);
        while (!await CheckTransactionAsync(generationResponse!.TransactionHash!))
        {
            await Task.Delay(1000, cancellationToken);
        }

        var doneNfts = await _cryptoWallet.ListGenerateNftGetAsync(generationResponse!.TransactionHash);
        var nftIndexes = new List<NftIndexDb>();
        foreach (var doneNftsToken in doneNfts!.Tokens)
        {
            var token = new NftIndexDb
            {
                TokenId = doneNftsToken,
                Url = request.Url,
                Price = request.Price
            };
            nftIndexes.Add(token);
        }

        await _repository.AddNftIndexesAsync(nftIndexes, cancellationToken);
    }

    private async Task<bool> CheckTransactionAsync(string hash)
    {
        var result = await _cryptoWallet.TransferStatusGetAsync(hash);
        return result?.Status == "Success";
    }
}
