using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Tickets.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection service)
    {
        service.AddControllers();
        
        return service;
    }
}