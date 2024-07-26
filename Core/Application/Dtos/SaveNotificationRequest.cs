using Domain.Entities;

namespace Application.Dtos;

public record SaveNotificationRequest(
    string To, 
    string Body,
    Guid CustomerId, 
    Priority Priority, 
    string Description,
    NotificationType Type,
    Customer? Customer);