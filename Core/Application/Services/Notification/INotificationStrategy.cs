using Application.Dtos;

namespace Application.Services.Notification;

public interface INotificationStrategy
{
    Task<SendNotificationResponse> Send(SendNotificationRequest request);
}