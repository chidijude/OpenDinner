using MediatR;
using OpenDinner.Domain.MenuAggregate.Events;

namespace OpenDinner.Application.Menus.Events;

public class DummyEventHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
       return Task.CompletedTask;
    }
}
