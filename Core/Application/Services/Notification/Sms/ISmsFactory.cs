namespace Application.Services.Notification.Sms;

public interface ISmsFactory
{
    ISmsStrategy CreateSmsStrategy(string smsProvider);
}