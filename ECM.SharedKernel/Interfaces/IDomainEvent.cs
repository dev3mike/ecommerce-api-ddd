namespace ECM.SharedKernel.Interfaces;

/// <summary>
/// Represents a domain event in the system.
/// </summary>
public interface IDomainEvent
{
        /// <summary>
        /// The date and time when the event occurred.
        /// </summary>
        DateTime OccurredOn { get; }
}