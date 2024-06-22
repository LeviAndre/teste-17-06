using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tickets.Application.Services.Ticket;
using Tickets.Contracts.Ticket;

namespace Tickets.Api.Controllers;

[ApiController]
[Route("tickets")]
[Authorize]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTicket(TicketRequest request)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdString == null)
        {
            return Unauthorized(new { Error = "Usuário não encontrado" });
        }

            if (!int.TryParse(userIdString, out var userId))
    {
        return Unauthorized(new { Error = "Invalid user ID" });
    }

        await _ticketService.CreateTicket(request.Title, request.Description, (int)userId);

        return Ok();
    }

    [HttpGet("find/{id}")]
    public async Task<IActionResult> FindTicket([FromRoute] int id)
    {
        var response = await _ticketService.FindTicket(id);

        return Ok(response);
    }

    [HttpGet("find/all")]
    public async Task<IActionResult> FindTickets()
    {
        var response = await _ticketService.FindTickets();

        return Ok(response);
    }
}