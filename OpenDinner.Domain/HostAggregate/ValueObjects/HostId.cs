
using OpenDinner.Domain.Common.Models;

namespace OpenDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; }
    public HostId(Guid value)
    {
        Value = value;
    }
    public HostId()
    {

    }
    public static HostId CreateUnique() => new(Guid.NewGuid());
    public static HostId Create(string hostId) => new(new Guid(hostId));
    public static HostId Create(Guid value) => new(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
