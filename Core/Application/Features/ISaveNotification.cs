using Application.Dtos;

namespace Application.Features;

public interface ISaveNotification
{
    Task Save(SaveNotificationRequest request);
}