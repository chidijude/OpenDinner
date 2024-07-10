﻿using OpenDinner.Domain.Common.Models;

namespace OpenDinner.Domain.Menu.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; }
    public MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}