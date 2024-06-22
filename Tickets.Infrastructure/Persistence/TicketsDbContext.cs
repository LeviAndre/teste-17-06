using Microsoft.EntityFrameworkCore;
using Tickets.Domain.Entities;

namespace Tickets.Infrastructure.Persistence;

public class TicketsDbContext : DbContext 
{
    public  TicketsDbContext(DbContextOptions<TicketsDbContext> options)
        : base (options)
        {

        }
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Ticket> Ticket { get; set; } = null!;
    public DbSet<TicketStatus> TicketStatus { get; set; } = null!;
}

