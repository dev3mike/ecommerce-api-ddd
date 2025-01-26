using ECM.Application.Commands;
using ECM.Domain.Entities;
using ECM.Infrastructure.Interfaces;
using MediatR;

namespace ECM.Application.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = request.Password;
        var user = new User(request.Name, request.Email, hashedPassword);
        await _userRepository.AddAsync(user);

        return user.Id;
    }
}