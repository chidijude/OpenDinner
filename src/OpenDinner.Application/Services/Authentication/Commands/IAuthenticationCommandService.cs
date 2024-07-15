using ErrorOr;
using FluentResults;
using OneOf;
using OpenDinner.Application.Common.Errors;
using OpenDinner.Application.Services.Authentication.Common;

namespace OpenDinner.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    //OneOf<AuthenticationResult, IError> Register(string firstName, string lastName, string email, string password);
    //Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

}