using ECM.SharedKernel;

namespace ECM.Infrastructure.Interfaces;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(AggregateRoot aggregateRoot);
}