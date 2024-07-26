using Application.Dtos;

namespace Application.Services.Notification;

public interface INotificationFactory
{
    INotificationStrategy CreateNotificationStrategy(SendNotificationRequest request);
}