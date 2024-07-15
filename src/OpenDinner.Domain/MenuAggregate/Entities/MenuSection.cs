﻿using OpenDinner.Domain.Common.Models;
using OpenDinner.Domain.MenuAggregate.ValueObjects;

namespace OpenDinner.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{  
    private readonly List<MenuItem> _items = [];

    public string Name {get; private set; }
    public string Description {get; private set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    #pragma warning disable CS8618
    public MenuSection()
    {
        
    }
    #pragma warning restore CS8618

    public MenuSection(MenuSectionId id, string name, string description)
      : base(id)
    {
        Name = name;
        Description = description;
    }
    public MenuSection(MenuSectionId id, string name, string description, List<MenuItem> items)
     : base(id)
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public static MenuSection Create(string name, string description)
    {
        return new(
            MenuSectionId.CreateUnique(),
            name,
            description);
    }

    public static MenuSection Create(string name, string description, List<MenuItem> items)
    {
        return new(
            MenuSectionId.CreateUnique(),
            name,
            description,
            items);
    }


}