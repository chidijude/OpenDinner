using BuberDinner.Domain.Entities;

namespace OpenDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);