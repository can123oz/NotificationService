using Application.Dtos;
using Application.QueueConsumer;
using Application.Services;
using MassTransit;

namespace Persistence.QueueConsumer;

public class NotificationRabbitMqConsumer : IMessageConsumer<SendNotificationRequest>
{
    private readonly INotificationSender _notificationSender;

    public NotificationRabbitMqConsumer(INotificationSender notificationSender)
    {
        _notificationSender = notificationSender;
    }

    public async Task Consume(ConsumeContext<SendNotificationRequest> context)
    {
        Console.WriteLine("Incoming Message : " + context);

        if (context.Message is null) throw new Exception();

        await _notificationSender.Send(context.Message);
    }
}