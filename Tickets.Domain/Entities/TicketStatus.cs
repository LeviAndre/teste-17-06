using System.ComponentModel.DataAnnotations;

namespace Tickets.Domain.Entities;

public class TicketStatus
{
    [Key]
    public int? Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}