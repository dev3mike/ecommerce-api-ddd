using ECM.Application.DTOs;
using MediatR;

namespace ECM.Application.Queries;

public class GetUserByIdQuery : IRequest<GetUserByIdResponse>
{
    public Guid Id { get; set; }

    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
}