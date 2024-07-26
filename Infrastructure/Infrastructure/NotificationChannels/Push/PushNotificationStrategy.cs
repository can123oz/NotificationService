using Application.Dtos;
using Application.Services.Notification;

namespace Infrastructure.NotificationChannels.Push;

public class PushNotificationStrategy : INotificationStrategy
{
    public async Task<SendNotificationResponse> Send(SendNotificationRequest request)
    {
        Console.WriteLine("Notification Sent with Push");
        return new SendNotificationResponse(true,"Notification sent with push");
    }
}