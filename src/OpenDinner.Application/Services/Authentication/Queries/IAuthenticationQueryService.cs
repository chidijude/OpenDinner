using ErrorOr;
using FluentResults;
using OneOf;
using OpenDinner.Application.Common.Errors;
using OpenDinner.Application.Services.Authentication.Common;

namespace OpenDinner.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login( string email, string password);
}