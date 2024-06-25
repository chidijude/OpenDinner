using OpenDinner.Application.Services.Authentication;
using OpenDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OpenDinner.Application.Common.Errors;
using OneOf;
using FluentResults;
using ErrorOr;
using OpenDinner.Domain.Common.Errors;

namespace OpenDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [Route("register")]
    [HttpPost]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> registerResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        return registerResult.Match(
           authResult => Ok(MapAuthResult(authResult)),
           errors => Problem(errors)); //Problem method here is from the ApiController created.

        #region Fluent Error Region
        //if (registerResult.IsT0)
        //{
        //    var authResult = registerResult.AsT0;
        //    AuthenticationResponse response = MapAuthResult(authResult);

        //    return Ok(response);
        //}
        //return Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exist");

        //if (registerResult.IsSuccess)
        //{
        //    return Ok(MapAuthResult(registerResult.Value));
        //}

        //var firstError = registerResult.Errors[0];

        //if (firstError is DuplicateEmailError)
        //{
        //    return Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exist");
        //}
        //return Problem(); 
        #endregion

        #region OneOf Section
        //return registerResult.Match(
        //   authResult => Ok(MapAuthResult(authResult)),
        //   error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage));

        //if (registerResult.IsT0)
        //{
        //    var authResult = registerResult.AsT0;
        //    AuthenticationResponse response = MapAuthResult(authResult);

        //    return Ok(response);
        //}
        //return Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exist");
        #endregion

    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
    }

    [Route("login")]
    [HttpPost]
    public IActionResult Login(LoginRequest request)
    {
        var loginResult = _authenticationService.Login(           
            request.Email,
            request.Password
        );

        if (loginResult.IsError && loginResult.FirstError == Errors.Authentication.InvalidCredentials) 
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: loginResult.FirstError.Description);
        }

        return loginResult.Match(
          authResult => Ok(MapAuthResult(authResult)),
          errors => Problem(errors));       
       
    }
}