using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string To { get; set; }
        public string Priority { get; set; }
        public string Provider { get; set; }
        public string Body { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
