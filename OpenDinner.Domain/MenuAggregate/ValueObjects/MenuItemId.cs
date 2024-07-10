using OpenDinner.Domain.Common.Models;

namespace OpenDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; }
    public MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
