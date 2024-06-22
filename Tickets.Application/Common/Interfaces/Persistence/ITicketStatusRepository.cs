using Tickets.Domain.Entities;

namespace Tickets.Application.Common.Interfaces.Persistence;

public interface ITicketStatusRepository
{
    Task<List<TicketStatus>> GetAllTicketStatus();
}