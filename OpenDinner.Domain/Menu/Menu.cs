using OpenDinner.Domain.Common.Models;
using OpenDinner.Domain.Dinner.ValueObjects;
using OpenDinner.Domain.Host.ValueObjects;
using OpenDinner.Domain.Menu.Entities;
using OpenDinner.Domain.Menu.ValueObjects;
using OpenDinner.Domain.MenuReview.ValueObjects;

namespace OpenDinner.Domain.Menu;

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

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();



}
