using ECM.Application.Commands;
using ECM.Application.DTOs;
using ECM.Application.Queries;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var query = new GetUserByIdQuery(id);
        var user = await mediator.Send(query);
        if (user is null)
            return NotFound($"User with ID {id} not found.");

        return Ok(user);    
    }
}