namespace Tickets.Application.Services.Ticket;

public record TicketResult(
    int? Id, 
    string Title,
    string Description,
    int? StatusId,
    int? UserId
);