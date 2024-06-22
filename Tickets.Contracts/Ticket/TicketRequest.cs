namespace Tickets.Contracts.Ticket;

public record TicketRequest(
    string Title, 
    string Description
);