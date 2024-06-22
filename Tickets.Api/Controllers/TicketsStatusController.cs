using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tickets.Application.Services.Ticket;
using Tickets.Contracts.Ticket;

namespace Tickets.Api.Controllers;

[ApiController]
[Route("ticket-status")]
[Authorize]
public class TicketsStatusController : ControllerBase
{
    private readonly ITicketStatusService _ticketStatusService;

    public TicketsStatusController(ITicketStatusService ticketStatusService)
    {
        _ticketStatusService = ticketStatusService;
    }

    [HttpGet("find/all")]
    public async Task<IActionResult> FindAllTicketStatus()
    {
        var response = await _ticketStatusService.FindAllTicketStatus();

        return Ok(response);
    }
}