using OpenDinner.Domain.Common.Models;

namespace OpenDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObject
{
    public Guid Value { get; }
    public MenuId(Guid value)
    {
        Value = value;
    }
    public MenuId()
    {
        
    }

    public static MenuId CreateUnique() => new(Guid.NewGuid());
    public static MenuId Create(Guid value) => new(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
