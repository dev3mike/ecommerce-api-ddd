using ECM.Domain.Entities;
using ECM.SharedKernel.Interfaces;
using MediatR;

namespace ECM.Domain.Events;

public class UserCreated(User user) : IDomainEvent, INotification
{
    public User User { get; } = user;
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}