using ECM.Infrastructure.Interfaces;
using ECM.SharedKernel;
using MediatR;

namespace ECM.Infrastructure;

internal class DomainEventDispatcher(IMediator mediator) : IDomainEventDispatcher
{
    public async Task DispatchAsync(AggregateRoot aggregateRoot)
    {
        var domainEvents = aggregateRoot.DomainEvents.ToList();

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }

        aggregateRoot.ClearDomainEvents();
    }
}