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
}
