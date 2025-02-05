using ECM.Domain.Events;
using ECM.SharedKernel;

namespace ECM.Domain.Entities;

public class User : AggregateRoot
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ICollection<Organization> Organizations { get; private set; } = new List<Organization>();

    private User() { } // For EF Core

    public User(string name, string email, string password)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        CreatedAt = DateTime.UtcNow;
        
        AddDomainEvent(new UserCreated(this));
    }
}