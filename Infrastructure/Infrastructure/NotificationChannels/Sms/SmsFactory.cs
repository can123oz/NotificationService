using Application.Services.Notification.Sms;

namespace Infrastructure.NotificationChannels.Sms;

public static class SmsFactory
{
    public static ISmsStrategy CreateSmsStrategy(string smsProvider)
    {
        return smsProvider switch
        {
            "Twillio" => new TwillioSmsService(),
            "Amazon" => new AmazonSnsSmsService(),
            _ => throw new ArgumentException("Invalid SMS provider type")
        };
    }
    
    // TODO code smell fix it later after the task..
    public static ISmsStrategy CreateSmsStrategyWhenFail(string smsProvider)
    {
        return smsProvider switch
        {
            "Twillio" => new AmazonSnsSmsService(),
            "Amazon" => new TwillioSmsService(),
            _ => throw new ArgumentException("Invalid SMS provider type")
        };
    }
}