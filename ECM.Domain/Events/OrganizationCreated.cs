using ECM.Domain.Entities;
using ECM.SharedKernel.Interfaces;
using MediatR;

namespace ECM.Domain.Events;

public class OrganizationCreated(Organization organization) : IDomainEvent, INotification
{
    public Organization Organization { get; } = organization;
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}