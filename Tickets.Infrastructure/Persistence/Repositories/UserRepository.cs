using Microsoft.EntityFrameworkCore;
using Tickets.Application.Common.Interfaces.Persistence;
using Tickets.Domain.Entities;

namespace Tickets.Infrastructure.Persistence;

public class UserRepository : IUserRepository 
{
    private readonly TicketsDbContext _dbContext;

    public UserRepository(TicketsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetUserByEmail(string email) 
    {
        return await _dbContext.Users.SingleOrDefaultAsync(user => user.Email == email);   
    }

    public async Task Add(User user)
    {
        await _dbContext.AddAsync(user);

        await _dbContext.SaveChangesAsync();
    }
}