using Application.Dtos;

namespace Application.Services.Notification.Sms;

public interface ISmsStrategy
{
    Task<SendNotificationResponse> Send(SendNotificationRequest request);
}