using System.ComponentModel.DataAnnotations;

namespace Tickets.Domain.Entities;

public class User
{
    [Key]
    public int? Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}