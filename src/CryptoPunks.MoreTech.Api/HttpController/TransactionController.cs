using CryptoPunks.MoreTech.Api.Actions.Transaction.Transfer;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CryptoPunks.MoreTech.Api.HttpController;

[ApiController]
[Route("v1/transaction")]
public class TransactionController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionController(IMediator mediator)
        => _mediator = mediator;

    [HttpPost("matic/")]
    public async Task<ActionResult<TransferResponse>> MaticTransaction([FromBody] TransferMaticCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPost("ruble/")]
    public async Task<ActionResult<TransferResponse>> RubleTransaction([FromBody] TransferRubleCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPost("nft/")]
    public async Task<ActionResult<TransferResponse>> NftTransaction([FromBody] TransferNftCommand command)
        => Ok(await _mediator.Send(command));
}
