using Tickets.Domain.Entities;

namespace Tickets.Contracts.Authentication.Common;

public record AuthenticationResult(
    User User, 
    string Token
);