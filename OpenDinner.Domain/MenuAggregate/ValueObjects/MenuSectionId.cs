using OpenDinner.Domain.Common.Models;

namespace OpenDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; }
    public MenuSectionId(Guid value)
    {
        Value = value;
    }
    public MenuSectionId()
    {
        
    }
    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());
    public static MenuSectionId Create(Guid value) => new(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
