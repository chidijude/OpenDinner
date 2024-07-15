﻿using OpenDinner.Domain.Common.Models;
using OpenDinner.Domain.MenuAggregate.ValueObjects;

namespace OpenDinner.Domain.MenuAggregate.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public MenuItem(MenuItemId id, string name, string description)
            :base(id)
        {
            Name = name;
            Description = description;
        }
        #pragma warning disable CS8618
        public MenuItem()
        {
            
        }
        #pragma warning restore CS8618


        public static MenuItem Create(string name, string description)
        {
            return new(
                MenuItemId.CreateUnique(),
                name,
                description);
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
