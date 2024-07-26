using Application.Dtos;
using Application.Features;
using Application.Services;
using Application.Services.Notification;
using Domain.Entities;

namespace Infrastructure;

public class NotificationSender : INotificationSender
{
    private readonly INotificationFactory _factory;
    private readonly ISaveCustomer _saveCustomer;
    private readonly ISaveNotification _saveNotification;

    public NotificationSender(
        INotificationFactory factory,
        ISaveCustomer saveCustomer,
        ISaveNotification saveNotification)
    {
        _factory = factory;
        _saveCustomer = saveCustomer;
        _saveNotification = saveNotification;
    }

    public async Task<SendNotificationResponse> Send(SendNotificationRequest request)
    {
        if (!Configuration.IsNotificationTypeActive(request.Type.ToString()))
        {
            return new SendNotificationResponse(false, "Notification type is inactive");
        }

        try
        {

            INotificationStrategy strategy = _factory.CreateNotificationStrategy(request);
            SendNotificationResponse response = await strategy.Send(request);

            // TODO there is a missing part can make db migrations in the docker-compose so cant save???
            // fix the docker-compose migrations.
            /*
            SaveCustomerRequest saveCustomerRequest = new SaveCustomerRequest(request.CustomerId, "");
            Customer customer = await _saveCustomer.Save(saveCustomerRequest);

            SaveNotificationRequest saveNotificationRequest = new SaveNotificationRequest(
                request.To,
                request.Body,
                request.CustomerId,
                request.Priority,
                request.Description,
                request.Type,
                customer);
            await _saveNotification.Save(saveNotificationRequest);
             */

            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}