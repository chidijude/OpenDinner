using BuberDinner.Domain.Entities;
using ErrorOr;
using FluentResults;
using OneOf;
using OpenDinner.Application.Common.Errors;
using OpenDinner.Application.Common.Interfaces.Authentication;
using OpenDinner.Application.Persistence;
using OpenDinner.Application.Services.Authentication.Common;
using OpenDinner.Domain.Common.Errors;

namespace OpenDinner.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        //Validate the user doesn't exist.
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
            //return Result.Fail< AuthenticationResult>(new[] { new DuplicateEmailError() }); //For Fluent Error
        }

        //Create user (generate unique ID) and persist to DB
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        //Create JWT token.
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}