using System.ComponentModel.DataAnnotations;

namespace Tickets.Domain.Entities;

public class Ticket
{
    [Key]
    public int? Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string StatusId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = new DateTime();
    public DateTime UpdatedAt { get; set; } = new DateTime();
}