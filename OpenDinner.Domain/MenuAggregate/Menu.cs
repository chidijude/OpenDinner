using OpenDinner.Domain.Common.Models;
using OpenDinner.Domain.DinnerAggregate.ValueObjects;
using OpenDinner.Domain.HostAggregate.ValueObjects;
using OpenDinner.Domain.MenuAggregate.Entities;
using OpenDinner.Domain.MenuAggregate.ValueObjects;
using OpenDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace OpenDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    public string Name { get; }
    public HostId HostId { get; }
    public string Description { get; }
    public float AverageRating { get; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private readonly List<MenuSection> _sections = [];
    private readonly List<DinnerId> _dinnerIds = [];
    private readonly List<MenuReviewId> _menuReviewIds = [];

    public Menu(
        MenuId id, 
        string name, 
        HostId hostId,
        string description, 
        DateTime createdDateTime, 
        DateTime updatedDateTime): base(id)
    {
        Name = name;
        HostId = hostId;
        Description = description;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public Menu(
       MenuId id,
       string name,
       HostId hostId,
       string description,
       DateTime createdDateTime,
       DateTime updatedDateTime,
       List<MenuSection> sections) : base(id)
    {
        Name = name;
        HostId = hostId;
        Description = description;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        _sections = sections;
    }

    public static Menu Create(string name, string description, HostId hostId)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            hostId,
            description,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
    public static Menu Create(string name, string description, HostId hostId, List<MenuSection> sections)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            hostId,
            description,
            DateTime.UtcNow,
            DateTime.UtcNow,
            sections);
    }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();



}
