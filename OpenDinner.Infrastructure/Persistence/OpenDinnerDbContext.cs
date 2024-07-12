using Microsoft.EntityFrameworkCore;
using OpenDinner.Domain.MenuAggregate;

namespace OpenDinner.Infrastructure.Persistence;

public class OpenDinnerDbContext: DbContext
{
    public OpenDinnerDbContext(DbContextOptions<OpenDinnerDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OpenDinnerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
