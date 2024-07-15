using OpenDinner.Application.Menus.Commands.CreateMenu;
using OpenDinner.Application.UnitTest.TestUtils.Constants;
using System.Linq;

namespace OpenDinner.Application.UnitTest.Menus.Commands.TestUtils;

public class CreateMenuCommandUtils
{
    //name
    //description
    //list of sections

    public static CreateMenuCommand CreateCommand(
        List<MenuSectionCommand> sections = null)
    {
        return new CreateMenuCommand(
            Constants.Host.HostId.Value.ToString()!,
            Constants.Menu.Name,
            Constants.Menu.Description,
            sections?? CreateSectionsCommand());
    }

    //sections
    //name
    //description
    //list of items

    public static List<MenuSectionCommand> CreateSectionsCommand(
         List<MenuItemCommand> items = null,
         int sectionCount = 1)
    {
        return Enumerable.Range(0, sectionCount)
            .Select(index => new MenuSectionCommand(
                Constants.Menu.SectionNameFromIndex(index),
                Constants.Menu.SectionDescriptionFromIndex(index),
                items?? CreateItemsCommand()
            )).ToList();
        
    }

    //items
    //name
    //description
    public static List<MenuItemCommand> CreateItemsCommand(int itemCount = 1)
    {
        return Enumerable.Range(0, itemCount)
            .Select(index => new MenuItemCommand(
                Constants.Menu.SectionNameFromIndex(index),
                Constants.Menu.SectionDescriptionFromIndex(index)
            )).ToList();

    }

}
