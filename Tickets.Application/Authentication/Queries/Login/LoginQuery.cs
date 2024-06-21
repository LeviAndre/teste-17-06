using MediatR;
using Tickets.Application.Authentication.Common;

namespace Tickets.Application.Authentication.Query.Login;

public record LoginQuery(
    string Email,
    string Password
) : IRequest <AuthenticationResult>;