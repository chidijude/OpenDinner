﻿using OpenDinner.Domain.Common.Models;
using OpenDinner.Domain.Menu.ValueObjects;

namespace OpenDinner.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public MenuItem(MenuItemId id, string name, string description)
            :base(id)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description)
        {
            return new(
                MenuItemId.CreateUnique(),
                name,
                description);
        }

        public string Name { get; }
        public string Description { get; }
    }
}