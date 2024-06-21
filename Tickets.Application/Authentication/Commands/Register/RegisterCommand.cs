using MediatR;
using Tickets.Application.Authentication.Common;

namespace Tickets.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest <AuthenticationResult>;