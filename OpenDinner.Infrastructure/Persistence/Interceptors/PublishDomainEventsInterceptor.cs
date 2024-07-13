﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OpenDinner.Domain.Common.Models;

namespace OpenDinner.Infrastructure.Persistence.Interceptors;

public class PublishDomainEventsInterceptor : SaveChangesInterceptor
{
    private readonly IPublisher _mediator;
    public PublishDomainEventsInterceptor(IPublisher mediator)
    {
        _mediator = mediator;
    }
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await PublishDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private async Task PublishDomainEvents(DbContext? dbContext)
    {

        if (dbContext is null) 
        {
            return;
        }
        // Get all entities
        var entitiesWithDomaianEvents = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
            .Where(entry => entry.Entity.DomainEvents.Any())
            .Select(entry => entry.Entity).ToList();

        //Get all Domain events
        var domainEvents = entitiesWithDomaianEvents.SelectMany(entry => entry.DomainEvents).ToList();

        //Clear domain events
        entitiesWithDomaianEvents.ForEach(entity => entity.ClearDomainEvents());

        //Publish domain events
        foreach ( var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent);
        }

    }
}
