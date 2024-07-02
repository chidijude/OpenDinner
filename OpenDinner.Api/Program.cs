using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using OpenDinner.Api;
using OpenDinner.Api.Common.Errors;
using OpenDinner.Application;
using OpenDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddInfrastructure(builder.Configuration)
                    .AddApplication()
                    .AddPresentation();
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, OpenDinnerProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    
    app.UseHttpsRedirection();
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.MapControllers();
    app.Run();
}

