using FluentResults;
using System.Net;

namespace OpenDinner.Application.Common.Errors;

public class DuplicateEmailError : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => throw new NotImplementedException();

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}

//public record struct DuplicateEmailError : IError
//{
//    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

//    public string ErrorMessage => "Email Already Exist";
//}
