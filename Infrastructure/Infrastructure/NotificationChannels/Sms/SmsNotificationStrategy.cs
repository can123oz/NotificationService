using Application.Dtos;
using Application.Services.Notification;
using Application.Services.Notification.Sms;
using Polly;
using Polly.Retry;

namespace Infrastructure.NotificationChannels.Sms;

public class SmsNotificationStrategy : INotificationStrategy
{
    private readonly AsyncRetryPolicy _retryPolicy;
    private string activeSmsProvider;
    private ISmsStrategy smsStrategy;

    public SmsNotificationStrategy()
    {
        activeSmsProvider = Configuration.ActiveSmsProvider;
        smsStrategy = SmsFactory.CreateSmsStrategy(activeSmsProvider);
        _retryPolicy = Policy
            .Handle<Exception>()
            .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (exception, timeSpan, retryCount, context) =>
                {
                    Console.WriteLine(
                        $"Retry {retryCount} after {timeSpan.Seconds} seconds due to: {exception.Message}");
                });
    }

    public async Task<SendNotificationResponse> Send(SendNotificationRequest request)
    {
        return await _retryPolicy.ExecuteAsync(async () =>
        {
            try
            {
                SendNotificationResponse response = await smsStrategy.Send(request);
                Console.WriteLine("Notification Sent with SMS");
                return response;
            }
            catch (Exception e)
            {
                smsStrategy = SmsFactory.CreateSmsStrategyWhenFail(activeSmsProvider);
                Console.WriteLine(e);
                throw;
            }
        });
    }
}