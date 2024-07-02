using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OpenDinner.Application.Services.Authentication.Commands;
using OpenDinner.Application.Services.Authentication.Queries;

namespace OpenDinner.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services){

        //services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        //services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();

        services.AddMediatR(typeof(DependencyInjection).Assembly);
        return services;
    }
}