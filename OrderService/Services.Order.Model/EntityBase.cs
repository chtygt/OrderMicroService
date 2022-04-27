using System.ComponentModel.DataAnnotations;

namespace Services.Order.Model;

public class EntityBase
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdateDate { get; set; }

    [ConcurrencyCheck]
    public Guid ConcurrencyStamp { get; set; } = Guid.NewGuid();
}