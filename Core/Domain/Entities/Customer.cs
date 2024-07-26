using Domain.Entities.Common;

namespace Domain.Entities;

public class Customer : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<Notification> Notifications { get; set; }
}