using ErrorOr;
using FluentResults;
using OneOf;
using OpenDinner.Application.Common.Errors;

namespace OpenDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    //OneOf<AuthenticationResult, IError> Register(string firstName, string lastName, string email, string password);
    //Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    ErrorOr<AuthenticationResult> Login( string email, string password);
}