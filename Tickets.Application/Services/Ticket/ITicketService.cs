namespace Tickets.Application.Services.Ticket;

public interface ITicketService
{
    Task<bool> CreateTicket(string title, string description, int userId);
    Task<TicketResult> FindTicket(int id);
    Task<List<TicketResult>> FindTickets();
}