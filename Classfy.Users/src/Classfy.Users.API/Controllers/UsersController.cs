using System.Net;
using Classfy.Users.Application.UseCases.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Classfy.Users.API.Controllers;

public class UsersController : BaseController
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost()]
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(CreateUserOutput))]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    public async Task<IActionResult> Create([FromBody] CreateUserInput input)
    {
        CreateUserOutput output = await _mediator.Send(input);
        return Ok(output);
    }
}
