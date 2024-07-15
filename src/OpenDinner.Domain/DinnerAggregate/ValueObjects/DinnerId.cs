﻿using OpenDinner.Domain.Common.Models;

namespace OpenDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerId : ValueObject
{
    public Guid Value { get; }
    public DinnerId(Guid value)
    {
        Value = value;
    }

    public DinnerId()
    {
            
    }

    public static DinnerId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}