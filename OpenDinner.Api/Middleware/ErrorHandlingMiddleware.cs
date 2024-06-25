using System.Net;
using System.Text.Json;

namespace OpenDinner.Api.Middleware;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context){
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception){
        var code = HttpStatusCode.InternalServerError; //500 

        var result = JsonSerializer.Serialize(new {error ="An error has occurred while processing your request"});
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}