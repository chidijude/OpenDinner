using BuberDinner.Domain.Entities;
using OpenDinner.Application.Persistence;

namespace OpenDinner.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = [];
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}