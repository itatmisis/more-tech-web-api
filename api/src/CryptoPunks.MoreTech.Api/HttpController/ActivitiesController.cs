using CryptoPunks.MoreTech.Api.Actions.Activity.Add;
using CryptoPunks.MoreTech.Api.Actions.Activity.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoPunks.MoreTech.Api.HttpController;

[ApiController]
[Route("v1/activities")]
public class ActivitiesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ActivitiesController(IMediator mediator)
        => _mediator = mediator;

    [HttpPost("quest")]
    public async Task<IActionResult> AddQuest([FromBody] AddQuestCommand command)
        => Ok(await _mediator.Send(command));

    [HttpGet("quests")]
    public async Task<IActionResult> AddQuest()
        => Ok(await _mediator.Send(new GetQuestCommand()));
}
