using Application.Dtos;

namespace Application.Services;

public interface INotificationSender
{
    Task<SendNotificationResponse> Send(SendNotificationRequest request);
}