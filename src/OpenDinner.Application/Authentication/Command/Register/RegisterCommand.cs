using ErrorOr;
using MediatR;
using OpenDinner.Application.Services.Authentication.Common;


namespace OpenDinner.Application.Authentication.Command.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>
{
}
