using FluentAssertions;
using OpenDinner.Application.Menus.Commands.CreateMenu;
using OpenDinner.Domain.MenuAggregate;
using OpenDinner.Domain.MenuAggregate.Entities;

namespace OpenDinner.Application.UnitTest.TestUtils.Menus.Extensions;

public static partial class MenuExtension
{
    public static void ValidateCreatedFrom(this Menu menu, CreateMenuCommand command)
    {
        menu.Name.Should().Be(command.Name);
        menu.Description.Should().Be(command.Description);

        menu.Sections.Should().HaveSameCount(command.Sections);
        menu.Sections.Zip(command.Sections).ToList().ForEach(pair => ValidateSection(pair.First, pair.Second));
    }

    public static void ValidateSection(this MenuSection section, MenuSectionCommand command)
    {
        section.Name.Should().Be(command.Name);
        section.Id.Should().NotBeNull();
        section.Description.Should().Be(command.Description);

        section.Items.Should().HaveSameCount(command.Items);
        section.Items.Zip(command.Items).ToList().ForEach(pair => ValidateItem(pair.First, pair.Second));
    }

    public static void ValidateItem(this MenuItem item, MenuItemCommand command)
    {
        item.Name.Should().Be(command.Name);
        item.Id.Should().NotBeNull();
        item.Description.Should().Be(command.Description);

    }
}
