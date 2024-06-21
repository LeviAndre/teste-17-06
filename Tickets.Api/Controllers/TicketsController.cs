using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tickets.Api.Controllers;

[ApiController]
[Route("tickets")]
[Authorize]
public class TicketsController : ControllerBase
{
    public IActionResult ListTickets()
    {
        return Ok(Array.Empty<string>());
    }
}