using CryptoPunks.MoreTech.Api.Actions.Wallet.GetBalance;
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

    [HttpGet("coins/{userId:long}")]
    public async Task<ActionResult<GetBalanceWalletResponse>> GetBalance(long userId)
        => Ok(await _mediator.Send(new GetBalanceWalletCommand(userId)));
}
