using Microsoft.Extensions.DependencyInjection;
using OpenDinner.Application.Services.Authentication;

namespace OpenDinner.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services){

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}