using ECM.Domain.Events;
using MediatR;

namespace ECM.Application.Handlers.Events;

public class UserCreatedEventHandler: INotificationHandler<UserCreated>
{
    public Task Handle(UserCreated notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"User Created: {notification.User.Name} ({notification.User.Email}) at {notification.OccurredOn}");

        return Task.CompletedTask;
    }
}