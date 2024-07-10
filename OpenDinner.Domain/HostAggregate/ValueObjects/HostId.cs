
using OpenDinner.Domain.Common.Models;

namespace OpenDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }
    public HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
