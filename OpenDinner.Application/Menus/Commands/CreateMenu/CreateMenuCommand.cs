using ErrorOr;
using MediatR;
using OpenDinner.Domain.MenuAggregate;

namespace OpenDinner.Application.Menus.Commands.CreateMenu
{

    public record CreateMenuCommand(
        string HostId,
        string Name,
        string Description,
        List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

    public record MenuSectionCommand(
        string Name,
        string Description,
        List<MenuItemCommand> Items);

    public record MenuItemCommand(
        string Name,
        string Description);
}
