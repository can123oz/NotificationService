using Application.Dtos;
using Application.Features;
using Application.Repositories;
using Domain.Entities;

namespace Infrastructure.Features;

public class SaveNotification : ISaveNotification
{
    private readonly INotificationWriteRepository _writeRepository;

    public SaveNotification(INotificationWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task Save(SaveNotificationRequest request)
    {
        try
        {
            Notification notification = new Notification();
            notification.To = request.To;
            notification.Type = request.Type.ToString();
            notification.Body = request.Body;
            notification.Customer = request.Customer!;
            notification.Priority = request.Priority.ToString();
            notification.Description = request.Description;
            notification.CustomerId = request.CustomerId;
            notification.Provider = Configuration.NotificationProvider(request.Type.ToString());
            
            await _writeRepository.AddAsync(notification);
            await _writeRepository.SaveAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}