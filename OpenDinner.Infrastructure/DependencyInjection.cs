using Microsoft.Extensions.DependencyInjection;
using OpenDinner.Application.Common.Interfaces.Authentication;
using OpenDinner.Application.Common.Interfaces.Services;
using OpenDinner.Infrastructure.Authentication;
using OpenDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using OpenDinner.Application.Persistence;
using OpenDinner.Infrastructure.Persistence;

namespace OpenDinner.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}