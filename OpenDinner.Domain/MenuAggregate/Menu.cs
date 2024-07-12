using OpenDinner.Domain.Common.Models;
using OpenDinner.Domain.Common.ValueObjects;
using OpenDinner.Domain.DinnerAggregate.ValueObjects;
using OpenDinner.Domain.HostAggregate.ValueObjects;
using OpenDinner.Domain.MenuAggregate.Entities;
using OpenDinner.Domain.MenuAggregate.ValueObjects;
using OpenDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace OpenDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    public string Name {get; private set; }
    public HostId HostId {get; private set; }
    public string Description {get; private set; }
    public AverageRating AverageRating {get; private set; }

    public DateTime CreatedDateTime {get; private set; }
    public DateTime UpdatedDateTime {get; private set; }

    private readonly List<MenuSection> _sections = [];
    private readonly List<DinnerId> _dinnerIds = [];
    private readonly List<MenuReviewId> _menuReviewIds = [];

    #pragma warning disable CS8618
    private Menu()
    {
        
    }
    #pragma warning restore CS8618


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
        AverageRating = AverageRating.CreateNew();
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
        AverageRating = AverageRating.CreateNew();
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
