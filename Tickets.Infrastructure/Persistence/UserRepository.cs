using Microsoft.VisualBasic;
using Tickets.Application.Common.Interfaces.Persistence;
using Tickets.Domain.Entities;

namespace Tickets.Infrastructure.Persistence;

public class UserRepository : IUserRepository 
{
    private static List<User> _users = new();
    public User? GetUserByEmail(string email) 
    {
        return _users.SingleOrDefault(el => el.Email == email);   
    }

    public void Add(User user)
    {
        _users.Add(user);
    }

}