using ECM.SharedKernel.Interfaces;

namespace ECM.SharedKernel;
/// <summary>
/// Base class for all aggregate roots in the domain.
/// </summary>
public abstract class AggregateRoot
{
    // List of domain events raised by this aggregate
    private readonly List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// Gets the list of domain events raised by the aggregate.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Adds a domain event to the aggregate.
    /// </summary>
    /// <param name="eventItem">The domain event to add.</param>
    protected void AddDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    /// <summary>
    /// Removes a domain event from the aggregate.
    /// </summary>
    /// <param name="eventItem">The domain event to remove.</param>
    public void RemoveDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents.Remove(eventItem);
    }

    /// <summary>
    /// Clears all domain events from the aggregate.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}