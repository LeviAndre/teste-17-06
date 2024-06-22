using Microsoft.EntityFrameworkCore;
using Tickets.Application.Common.Interfaces.Persistence;
using Tickets.Domain.Entities;

namespace Tickets.Infrastructure.Persistence;

public class TicketRepository : ITicketRepository
{
    private readonly TicketsDbContext _dbContext;

    public TicketRepository(TicketsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetUserByEmail(string email) 
    {
        return await _dbContext.Users.SingleOrDefaultAsync(user => user.Email == email);   
    }

    public async Task PostTicket(Ticket ticket)
    {
        await _dbContext.AddAsync(ticket);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<Ticket?> GetTicket(int id)
    {
        return await _dbContext.Ticket.SingleOrDefaultAsync(user => user.Id == id);   
    }

    public async Task<List<Ticket>> GetTickets()
    {
        return await _dbContext.Ticket.ToListAsync();   
    }
}