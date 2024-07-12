using ErrorOr;
using MediatR;
using OpenDinner.Application.Persistence;
using OpenDinner.Domain.HostAggregate.ValueObjects;
using OpenDinner.Domain.MenuAggregate;
using OpenDinner.Domain.MenuAggregate.Entities;

namespace OpenDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        //Create Menu

        var menu = Menu.Create(
            name: request.Name,
            description: request.Description,
            hostId: HostId.CreateUnique(request.HostId),
            sections: request.Sections.ConvertAll(section => MenuSection.Create(
                section.Name,
                description: section.Description,
                items: section.Items.ConvertAll(item => MenuItem.Create(item.Name, item.Description))
          )));
        //Persist Menu
        _menuRepository.Add(menu);
        //
        return menu;
    }
}
