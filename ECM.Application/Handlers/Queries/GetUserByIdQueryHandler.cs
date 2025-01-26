using ECM.Application.DTOs;
using ECM.Application.Queries;
using ECM.Infrastructure.Interfaces;
using MediatR;

namespace ECM.Application.Handlers.Queries;

public class GetUserByIdQueryHandler(IUserRepository userRepository)
    : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id);

        if (user == null)
            return null;

        return new GetUserByIdResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
    }
}