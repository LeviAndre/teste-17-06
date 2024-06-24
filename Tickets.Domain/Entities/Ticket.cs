using System.ComponentModel.DataAnnotations;

namespace Tickets.Domain.Entities;

public class Ticket
{
    [Key]
    public int? Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? StatusId { get; set; } = null!;
    public int? UserId { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}