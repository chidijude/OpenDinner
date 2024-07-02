using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenDinner.Application.Authentication.Command.Register;
using OpenDinner.Application.Authentication.Queries.Login;
using OpenDinner.Application.Services.Authentication.Common;
using OpenDinner.Contracts.Authentication;
using OpenDinner.Domain.Common.Errors;

namespace OpenDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [Route("register")]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request)
    {

        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

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
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var loginResult = await _mediator.Send(query);
        
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