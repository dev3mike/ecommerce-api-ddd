using ECM.Api.DTOs;
using ECM.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECM.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var userId = await mediator.Send(command);
        var response = new CreateUserResponse
        {
            Id = userId
        };
        return CreatedAtAction(nameof(CreateUser), new { id = userId }, response);
    }
}