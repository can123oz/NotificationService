using Application.Features;
using Application.Services;
using Application.Services.Notification;
using Infrastructure.Features;
using Infrastructure.NotificationChannels;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<INotificationSender, NotificationSender>();
        services.AddSingleton<INotificationFactory, NotificationFactory>();
        
        services.AddSingleton<ISaveCustomer, SaveCustomer>();
        services.AddSingleton<ISaveNotification, SaveNotification>();
    }
}