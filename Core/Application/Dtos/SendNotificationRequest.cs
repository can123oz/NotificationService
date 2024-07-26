namespace Application.Dtos;

public class SendNotificationRequest
{
    public string To { get; set; }
    public string Body { get; set; }
    public Guid CustomerId { get; set; }
    public Priority Priority { get; set; }
    public string Description { get; set; }
    public NotificationType Type { get; set; }   
}