using Application.Dtos;
using Application.Services.Notification;
using Infrastructure.NotificationChannels.EMail;
using Infrastructure.NotificationChannels.Push;
using Infrastructure.NotificationChannels.Sms;

namespace Infrastructure.NotificationChannels;

public class NotificationFactory : INotificationFactory
{
    public INotificationStrategy CreateNotificationStrategy(SendNotificationRequest request)
    {
        return request.Type switch
        {
            NotificationType.SMS => new SmsNotificationStrategy(),
            NotificationType.EMAIL => new EMailNotificationStrategy(),
            NotificationType.PUSH => new PushNotificationStrategy(),
            _ => throw new ArgumentException("Invalid notification type")
        };
    }
}