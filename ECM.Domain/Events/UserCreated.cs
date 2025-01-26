using ECM.Domain.Aggregates;
using ECM.SharedKernel.Interfaces;

namespace ECM.Domain.Events;

public class UserCreated(User user) : IDomainEvent
{
    public User User { get; } = user;
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}