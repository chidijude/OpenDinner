using FluentAssertions;
using Moq;
using OpenDinner.Application.Menus.Commands.CreateMenu;
using OpenDinner.Application.Persistence;
using OpenDinner.Application.UnitTest.Menus.Commands.TestUtils;
using OpenDinner.Application.UnitTest.TestUtils.Menus.Extensions;

namespace OpenDinner.Application.UnitTest.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandlerTests
{
    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IMenuRepository> _mockMenuRepositry;
    public CreateMenuCommandHandlerTests()
    {
        _mockMenuRepositry = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHandler(_mockMenuRepositry.Object);
    }
    //T1 : SUT- Logical Componet Under Test
    //T2 : Scenerio - what we are testing
    //T3 : Expected Outcome

    [Theory]
    [MemberData(nameof(ValidCreateMenuCommands))]
    public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
    {       
        //Act
        //Invoke the command Handler
        var result = await _handler.Handle(createMenuCommand, default);

        //Assert
        result.IsError.Should().BeFalse();
        result.Value.ValidateCreatedFrom(createMenuCommand);
        _mockMenuRepositry.Verify(m => m.Add(result.Value), Times.Once());

    }

    public static IEnumerable<object[]> ValidCreateMenuCommands()
    {
        yield return new[] { CreateMenuCommandUtils.CreateCommand() };

        yield return new[]
        {
            CreateMenuCommandUtils.CreateCommand(sections: CreateMenuCommandUtils.CreateSectionsCommand(sectionCount:3))
        };

        yield return new[]
        {
            CreateMenuCommandUtils.CreateCommand(sections: CreateMenuCommandUtils.CreateSectionsCommand(
                sectionCount: 3,
                items: CreateMenuCommandUtils.CreateItemsCommand(itemCount: 3)))
        };
    }
}
