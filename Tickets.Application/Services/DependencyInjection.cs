using Microsoft.Extensions.DependencyInjection;
using Tickets.Application.Services.Authentication;

namespace Tickets.Application.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    
        return services;
    }
}