namespace Tickets.Contracts.Authentication;

public record AuthenticationResponse(
    int? id,
    string FirstName,
    string LastName,
    string Email, 
    string Token
);