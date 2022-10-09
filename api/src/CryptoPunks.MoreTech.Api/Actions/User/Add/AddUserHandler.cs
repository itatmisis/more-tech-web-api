using CryptoPunks.MoreTech.Api.DataAccess.Repositories.User;
using CryptoPunks.MoreTech.Api.DataAccess.Repositories.Wallet;
using CryptoPunks.MoreTech.CryptoClient;
using JetBrains.Annotations;
using MediatR;

namespace CryptoPunks.MoreTech.Api.Actions.User.Add;

[UsedImplicitly]
public class AddUserHandler : IRequestHandler<AddUserCommand, AddUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IWalletRepository _walletRepository;
    private readonly CryptoWallet _cryptoWallet;

    public AddUserHandler(IUserRepository userRepository, IWalletRepository walletRepository, IHttpClientFactory factory)
    {
        _userRepository = userRepository;
        _walletRepository = walletRepository;
        _cryptoWallet = new CryptoWallet(factory);
    }

    public async Task<AddUserResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = new UserDb
        {
            Nickname = request.Nickname,
            Role = request.Role,
            Employer = request.Employer,
            SecondName = request.SecondName,
            MiddleName = request.MiddleName,
            FirstName = request.FirstName,
            ProfilePicUrl = request.ProfilePicUrl,
            JobTitle = request.JobTitle
        };

        var result = await _userRepository.AddUserAsync(dbUser, cancellationToken);

        var requestClientResult = await _cryptoWallet.NewWalletPostAsync();
        await _walletRepository.AddWalletAsync(
            new()
            {
                Owner = result,
                PublicKey = requestClientResult!.PublicKey,
                PrivateKey = requestClientResult!.PrivateKey
            }, cancellationToken);

        return new AddUserResponse(result);
    }
}
