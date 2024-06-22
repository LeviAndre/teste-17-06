using Microsoft.EntityFrameworkCore;
using Tickets.Application.Common.Interfaces.Persistence;
using Tickets.Domain.Entities;

namespace Tickets.Infrastructure.Persistence;

public class TicketStatusRepository : ITicketStatusRepository
{
    private readonly TicketsDbContext _dbContext;

    public TicketStatusRepository(TicketsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TicketStatus>> GetAllTicketStatus()
    {
        return await _dbContext.TicketStatus.ToListAsync();   
    }
}