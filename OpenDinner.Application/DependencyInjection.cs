using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OpenDinner.Application.Authentication.Command.Register;
using OpenDinner.Application.Common.Behaviours;
using OpenDinner.Application.Services.Authentication.Commands;
using OpenDinner.Application.Services.Authentication.Common;
using OpenDinner.Application.Services.Authentication.Queries;
using System.Reflection;

namespace OpenDinner.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services){

        //services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        //services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();

        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}