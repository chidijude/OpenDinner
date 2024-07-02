using ErrorOr;
using MediatR;
using OpenDinner.Application.Services.Authentication.Common;


namespace OpenDinner.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>
{
}
