using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Tickets.Application.Common.Interfaces.Authentication;
using Tickets.Application.Common.Interfaces.Persistence;
using Tickets.Infrastructure.Authentication;
using Tickets.Infrastructure.Persistence;

namespace Tickets.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration) 
    {
        services.AddAuth(configuration);
        services.AddDbContext<TicketsDbContext>(options => {
            options.UseSqlServer("Server=FCAMARA-DEVS-01;Database=Tickets;User Id=SA;Password=pswrd1234;TrustServerCertificate=true");
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<ITicketStatusRepository, TicketStatusRepository>();
    
        return services;
    }



    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration) 
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication( defaultScheme: JwtBearerDefaults.AuthenticationScheme )
            .AddJwtBearer(options => options.TokenValidationParameters  = new TokenValidationParameters{
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)
                )
            });

        return services;
    }
}
