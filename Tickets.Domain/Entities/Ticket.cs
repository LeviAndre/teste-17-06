using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tickets.Domain.Entities;

public class Ticket
{
    [Key]
    public int? Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? StatusId { get; set; } = null!;
    public int? UserId { get; set; } = null!;
}