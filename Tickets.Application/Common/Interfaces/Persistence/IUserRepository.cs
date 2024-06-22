using Tickets.Domain.Entities;

namespace Tickets.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task Add(User user);
}