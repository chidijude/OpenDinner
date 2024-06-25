using BuberDinner.Domain.Entities;

namespace OpenDinner.Application.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}