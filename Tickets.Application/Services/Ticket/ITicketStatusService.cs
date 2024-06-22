using Tickets.Domain.Entities;

namespace Tickets.Application.Services.Ticket;

public interface ITicketStatusService
{
    Task<List<TicketStatus>> FindAllTicketStatus();
}