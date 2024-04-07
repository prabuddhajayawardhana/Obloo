using Obloo.Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Obloo.Domain.Entities;
public class User : IAuditableEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public DateTimeOffset CreatedOnUtc { get; set; }
    public DateTimeOffset ModifiedOnUtc { get; set; }
}
