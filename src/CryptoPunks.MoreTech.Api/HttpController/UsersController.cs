using CryptoPunks.MoreTech.Api.Actions.User.Add;
using CryptoPunks.MoreTech.Api.Actions.User.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoPunks.MoreTech.Api.HttpController;

[ApiController]
[Route("v1/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
        => _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<AddUserResponse>> AddUser([FromBody] AddUserCommand command)
        => Ok(await _mediator.Send(command));

    [HttpGet("{userId:long}")]
    public async Task<ActionResult<GetUserResponse>> GetUser(long userId)
    {
        var command = new GetUserCommand(userId);
        return Ok(await _mediator.Send(command));
    }
}
