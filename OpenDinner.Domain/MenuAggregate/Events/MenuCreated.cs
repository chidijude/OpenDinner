using OpenDinner.Domain.Common.Models;

namespace OpenDinner.Domain.MenuAggregate.Events;

public record MenuCreated(Menu Menu): IDomainEvent;

