using System.Net;

namespace OpenDinner.Application.Common.Errors;

public interface IServiceException{

    public HttpStatusCode StatusCode {get;}
    public string ErrorMessage {get;}
}