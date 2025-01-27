using ECM.Domain.Events;
using ECM.SharedKernel;

namespace ECM.Domain.Entities;

public class Organization : AggregateRoot
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Guid OwnerId { get; private set; }
    public User Owner { get; private set; }

    private Organization() { } // For EF Core

    public Organization(string name, User owner)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.UtcNow;
        OwnerId = owner.Id;
        Owner = owner;
        
        AddDomainEvent(new OrganizationCreated(this));
    }
}