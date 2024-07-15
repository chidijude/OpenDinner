using BuberDinner.Domain.Entities;
using OpenDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using OpenDinner.Application.Common.Interfaces.Authentication;
using OpenDinner.Application.Persistence;
using OpenDinner.Application.Services.Authentication.Common;

namespace OpenDinner.Application.Authentication.Command.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        //Validate the user doesn't exist.
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
            //return Result.Fail< AuthenticationResult>(new[] { new DuplicateEmailError() }); //For Fluent Error
        }

        //Create user (generate unique ID) and persist to DB
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _userRepository.Add(user);

        //Create JWT token.
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
