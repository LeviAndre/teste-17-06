using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Tickets.Application.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
    
        return services;
    }
}