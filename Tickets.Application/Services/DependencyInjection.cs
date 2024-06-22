using Microsoft.Extensions.DependencyInjection;
using Tickets.Application.Services.Authentication;
using Tickets.Application.Services.Ticket;

namespace Tickets.Application.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddTransient<ITicketService, TicketService>();
        services.AddTransient<ITicketStatusService, TicketStatusService>();
    
        return services;
    }
}