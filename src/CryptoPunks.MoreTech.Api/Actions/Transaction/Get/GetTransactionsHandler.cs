using CryptoPunks.MoreTech.Api.DataAccess.Repositories.TransactionObject;
using CryptoPunks.MoreTech.Api.DataAccess.Repositories.User;
using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Wallet;
using CryptoPunks.MoreTech.Api.Dtos.UserModels;
using CryptoPunks.MoreTech.CryptoClient;
using CryptoPunks.MoreTech.CryptoClient.Models.Requests;
using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.Transaction.Get;

public class GetTransactionsHandler : IRequestHandler<GetTransactionsCommand, GetTransactionsResponse>
{
    private readonly CryptoWallet _cryptoWallet;
    private readonly IWalletRepository _walletRepository;
    private readonly IUserRepository _userRepository;

    public GetTransactionsHandler(
        CryptoWallet cryptoWallet,
        IWalletRepository walletRepository,
        IUserRepository userRepository)
    {
        _cryptoWallet = cryptoWallet;
        _walletRepository = walletRepository;
        _userRepository = userRepository;
    }

    public async Task<GetTransactionsResponse> Handle(
        GetTransactionsCommand request,
        CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetWalletByUserIdAsync(request.UserId, cancellationToken);
        var transactionHistoryReq = new RequestHistory(1, 0, "desc");
        var result = await _cryptoWallet.HistoryPostAsync(transactionHistoryReq, wallet.PublicKey);
        var list = new List<Dtos.TransactionsMOdels.Transaction>();
        if (result?.History is not null)
        {
            foreach (var responseHistoryItem in result.History)
            {
                var fromUser = await _walletRepository.GetWalletByPublicKeyAsync(
                    responseHistoryItem.From,
                    cancellationToken);
                var toUser = await _walletRepository.GetWalletByPublicKeyAsync(
                    responseHistoryItem.To,
                    cancellationToken);
                Dtos.UserModels.User? from = null;
                if (fromUser?.Owner is not null)
                {
                    var fromDb = await _userRepository.GetUserAsync(fromUser.Owner, cancellationToken);
                    var jobTitle = await _userRepository.GetJobTitleAsync(fromDb.JobTitle, cancellationToken);
                    from = new Dtos.UserModels.User()
                    {
                        Id = fromDb.Id!.Value,
                        EmployerId = fromDb.Employer,
                        FirstName = fromDb.FirstName,
                        SecondName = fromDb.SecondName,
                        MiddleName = fromDb.MiddleName,
                        JobTitle = new JobTitle(jobTitle.Id, jobTitle.Name, jobTitle.Description),
                        ProfilePicUrl = fromDb.ProfilePicUrl,
                        Points = fromDb.Points,
                        Levels = fromDb.Level,
                        Nickname = fromDb.Nickname,
                    };
                }

                var toDb = await _userRepository.GetUserAsync(toUser.Owner, cancellationToken);
                var jobTitleto = await _userRepository.GetJobTitleAsync(toDb.JobTitle, cancellationToken);
                var to = new Dtos.UserModels.User()
                {
                    Id = toUser.Id!.Value,
                    EmployerId = toDb.Employer,
                    FirstName = toDb.FirstName,
                    SecondName = toDb.SecondName,
                    MiddleName = toDb.MiddleName,
                    JobTitle = new JobTitle(jobTitleto.Id, jobTitleto.Name, jobTitleto.Description),
                    ProfilePicUrl = toDb.ProfilePicUrl,
                    Points = toDb.Points,
                    Levels = toDb.Level,
                    Nickname = toDb.Nickname,
                };
                TokenType type;
                type = responseHistoryItem.TokenName == "NFT" ? TokenType.NFT :
                    responseHistoryItem.TokenName == "Wrapped Matic" ? TokenType.Matic : TokenType.DigitalRuble;

                var tObject = new TransactionObjectDb
                {
                    Descriminator = type,
                    DigitalRubValue = responseHistoryItem.Value,
                    MaticValue = responseHistoryItem.Value,
                    TokenId = responseHistoryItem.TokenId
                };
                list.Add(new Dtos.TransactionsMOdels.Transaction(from, to, tObject, DateTimeOffset.FromUnixTimeSeconds(responseHistoryItem!.TimeStamp).DateTime));
            }
        }

        return new GetTransactionsResponse(list);
    }
}
