using BuberDinner.Domain.Entities;

namespace OpenDinner.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);