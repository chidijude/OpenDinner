using BuberDinner.Domain.Entities;
using ErrorOr;
using FluentResults;
using OneOf;
using OpenDinner.Application.Common.Errors;
using OpenDinner.Application.Common.Interfaces.Authentication;
using OpenDinner.Application.Persistence;
using OpenDinner.Application.Services.Authentication.Common;
using OpenDinner.Application.Services.Authentication.Queries;
using OpenDinner.Domain.Common.Errors;

namespace OpenDinner.Application.Services.Authentication.Commands;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }  
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // 1. Validate the user doesn't exist.
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        // 2. Validate password is correct
        if (user.Password != password)
        {
            return new[] { Errors.Authentication.InvalidCredentials };
        }
        // Create JWT token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }


}