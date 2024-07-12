using OpenDinner.Application.Persistence;
using OpenDinner.Domain.MenuAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDinner.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly OpenDinnerDbContext _dbContext;

        public MenuRepository(OpenDinnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Menu menu)
        {
            _dbContext.Add(menu);
            _dbContext.SaveChanges();
        }
    }
}
