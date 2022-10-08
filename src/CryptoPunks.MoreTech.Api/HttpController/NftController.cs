using CryptoPunks.MoreTech.Api.Actions.Nft.Generate;
using CryptoPunks.MoreTech.Api.Actions.Nft.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoPunks.MoreTech.Api.HttpController;

[ApiController]
[Route("nft")]
public class NftController : ControllerBase
{
    private readonly IMediator _mediator;

    public NftController(IMediator mediator)
        => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> GenerateNft(GenerateNftCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("{userId:long}")]
    public async Task<ActionResult<GetNftsResponse>> GetNfts(long userId)
    {
        var command = new GetNftsCommand(userId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
