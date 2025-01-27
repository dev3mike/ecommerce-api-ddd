using ECM.Application.Commands;
using ECM.Domain.Entities;
using ECM.Infrastructure.Interfaces;
using ECM.Infrastructure.Services;
using MediatR;

namespace ECM.Application.Handlers.Commands;

public class CreateUserCommandHandler(UserOrganizationService userOrganizationService)
    : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly UserOrganizationService _userOrganizationService = userOrganizationService ?? throw new ArgumentNullException(nameof(userOrganizationService));

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var (user, _) = await _userOrganizationService.CreateUserWithOrganizationAsync(
            request.Name,
            request.Email,
            request.Password
        );

        return user.Id;
    }
}