using Tickets.Contracts.Authentication.Common;

namespace Tickets.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService 
{
    AuthenticationResult Login(string email, string password);
}