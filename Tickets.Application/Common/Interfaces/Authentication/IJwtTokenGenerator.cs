using Tickets.Domain.Entities;

namespace Tickets.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
