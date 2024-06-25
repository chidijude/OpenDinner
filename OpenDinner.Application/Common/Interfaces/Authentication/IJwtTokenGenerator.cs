using BuberDinner.Domain.Entities;

namespace OpenDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}