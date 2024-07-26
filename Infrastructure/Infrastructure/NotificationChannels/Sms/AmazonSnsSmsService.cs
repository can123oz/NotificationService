using Application.Dtos;
using Application.Services.Notification.Sms;

namespace Infrastructure.NotificationChannels.Sms;

public class AmazonSnsSmsService : ISmsStrategy
{
    public async Task<SendNotificationResponse> Send(SendNotificationRequest request)
    {
        Console.WriteLine("Notification Sent with SMS AMAZON");
        return new SendNotificationResponse(true, "Notification delivered with Amazon SNS");
    }
}