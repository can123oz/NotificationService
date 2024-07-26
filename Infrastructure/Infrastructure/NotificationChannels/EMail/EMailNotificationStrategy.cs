using System.Net;
using System.Net.Mail;
using Application.Dtos;
using Application.Services.Notification;
using Polly;
using Polly.Retry;

namespace Infrastructure.NotificationChannels.EMail;

public class EMailNotificationStrategy : INotificationStrategy
{
    private readonly AsyncRetryPolicy _retryPolicy;

    public EMailNotificationStrategy()
    {
        _retryPolicy = Policy
            .Handle<Exception>()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
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
                MailMessage mail = new MailMessage(
                    Configuration.GetSenderMail,
                    request.To,
                    request.Description,
                    request.Body);

                SmtpClient smtpClient = new SmtpClient();

                smtpClient.Credentials =
                    new NetworkCredential(Configuration.GetSenderMail, Configuration.GetEmailPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";

                await smtpClient.SendMailAsync(mail);

                Console.WriteLine("Notification Sent with Mail");
                return new SendNotificationResponse(true, "Notification sent to " + request.To + " with mail.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        });
    }
}