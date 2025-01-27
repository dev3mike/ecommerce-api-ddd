using ECM.Application.Commands;
using ECM.Application.DTOs;
using ECM.Application.Queries;
using ECM.Domain.Exceptions;
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
        try
        {
            var userId = await mediator.Send(command);
            var response = new CreateUserResponse
            {
                Id = userId
            };
            return CreatedAtAction(nameof(CreateUser), new { id = userId }, response);
        }
        catch (DuplicateEmailException exception)
        {
            return Conflict(new { message = exception.Message, email = exception.Email });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
        }
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