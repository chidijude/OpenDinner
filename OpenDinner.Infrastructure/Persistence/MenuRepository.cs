using OpenDinner.Application.Persistence;
using OpenDinner.Domain.MenuAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDinner.Infrastructure.Persistence
{
    public class MenuRepository : IMenuRepository
    {
        private static readonly List<Menu> _menus = [];
        public void Add(Menu menu)
        {
            _menus.Add(menu);
        }

        public static IReadOnlyCollection<Menu> Menus => _menus.AsReadOnly();
    }
}
