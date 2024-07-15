using OpenDinner.Domain.MenuAggregate;

namespace OpenDinner.Application.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}
