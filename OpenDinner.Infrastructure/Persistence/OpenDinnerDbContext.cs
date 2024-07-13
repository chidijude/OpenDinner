using Microsoft.EntityFrameworkCore;
using OpenDinner.Domain.Common.Models;
using OpenDinner.Domain.MenuAggregate;
using OpenDinner.Infrastructure.Persistence.Interceptors;

namespace OpenDinner.Infrastructure.Persistence;

public class OpenDinnerDbContext: DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    
    public OpenDinnerDbContext(DbContextOptions<OpenDinnerDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor)
        : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;

    }
    public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(OpenDinnerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
