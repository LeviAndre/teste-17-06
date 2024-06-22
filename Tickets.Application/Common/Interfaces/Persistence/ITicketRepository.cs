using Tickets.Domain.Entities;

namespace Tickets.Application.Common.Interfaces.Persistence;

public interface ITicketRepository
{
    Task PostTicket(Ticket ticket);
    Task<Ticket?> GetTicket(int id);
    Task<List<Ticket>> GetTickets();
}