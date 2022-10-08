using CryptoPunks.MoreTech.Api.Actions.User.Add;
using CryptoPunks.MoreTech.Api.Actions.Wallet.Add;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoPunks.MoreTech.Api.HttpController;

[ApiController]
[Route("v1/wallet")]
public class WalletController : ControllerBase
{
    private readonly IMediator _mediator;

    public WalletController(IMediator mediator)
        => _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<AddWalletResponse>> AddWallet(AddUserCommand command)
        => Ok(await _mediator.Send(command));
}
