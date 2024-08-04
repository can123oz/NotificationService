using Application.Dtos;
using Application.QueueConsumer;
using Application.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.QueueConsumer;
using Persistence.Context;
using Persistence.Repositories;
using RabbitMQ.Client;

namespace Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<NotificationServiceDbContext>(options =>
            options.UseNpgsql(Configuration.ConnectionString), ServiceLifetime.Singleton);

        services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
        services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();

        services.AddSingleton<INotificationReadRepository, NotificationReadRepository>();
        services.AddSingleton<INotificationWriteRepository, NotificationWriteRepository>();
        
        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter();

            config.AddConsumer<NotificationRabbitMqConsumer>();
            
            config.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(Configuration.GetRabbitMqConfig.Host!, "/", h =>
                {
                    h.Password(Configuration.GetRabbitMqConfig.Password!);
                    h.Username(Configuration.GetRabbitMqConfig.UserName!);
                });
                cfg.ConfigureEndpoints(context);
            });
        });
        
        services.AddSingleton<IMessageConsumer<SendNotificationRequest>, NotificationRabbitMqConsumer>();

        services.AddHealthChecks()
            .AddNpgSql(Configuration.ConnectionString);
    }
}