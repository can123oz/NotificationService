using Application.Dtos;
using Application.Services.Notification.Sms;

namespace Infrastructure.NotificationChannels.Sms;

public class TwillioSmsService : ISmsStrategy
{
    public async Task<SendNotificationResponse> Send(SendNotificationRequest request)
    {
        if (request.Body == "string")
        {
            // MOCKING THE EXCEPTION TO SEE THE CHANGING PROVIDER
            throw new Exception();
        }
        Console.WriteLine("Notification Sent with SMS TWILLIO");
        return new SendNotificationResponse(true,"Notification delivered with Twillio");
    }
}