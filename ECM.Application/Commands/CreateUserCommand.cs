using MediatR;

namespace ECM.Application.Commands;

public class CreateUserCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}