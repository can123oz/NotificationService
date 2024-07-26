using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class NotificationReadRepository : ReadRepository<Notification>, INotificationReadRepository
{
    public NotificationReadRepository(NotificationServiceDbContext context) : base(context)
    {
    }
}