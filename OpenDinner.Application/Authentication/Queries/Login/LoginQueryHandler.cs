
using BuberDinner.Domain.Entities;
using OpenDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using OpenDinner.Application.Common.Interfaces.Authentication;
using OpenDinner.Application.Persistence;
using OpenDinner.Application.Services.Authentication.Common;

namespace OpenDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // 1. Validate the user doesn't exist.
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        // 2. Validate password is correct
        if (user.Password != query.Password)
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

