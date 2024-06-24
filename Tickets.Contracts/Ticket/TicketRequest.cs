namespace Tickets.Contracts.Ticket;

public record TicketRequest(
    string title, 
    string description
);