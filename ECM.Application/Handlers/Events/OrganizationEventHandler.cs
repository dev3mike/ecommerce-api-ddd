using ECM.Domain.Events;
using MediatR;

namespace ECM.Application.Handlers.Events;

public class OrganizationCreatedEventHandler: INotificationHandler<OrganizationCreated>
{
    public Task Handle(OrganizationCreated notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Organization Created: {notification.Organization.Name} ({notification.Organization.Owner.Email}) at {notification.OccurredOn}");

        return Task.CompletedTask;
    }
}