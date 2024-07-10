using OpenDinner.Domain.Common.Models;

namespace OpenDinner.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
    public Guid Value { get; }
    public MenuReviewId(Guid value)
    {
        Value = value;
    }

    public static MenuReviewId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
