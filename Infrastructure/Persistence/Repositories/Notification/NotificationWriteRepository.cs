using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class NotificationWriteRepository : WriteRepository<Notification>, INotificationWriteRepository
{
    public NotificationWriteRepository(NotificationServiceDbContext context) : base(context)
    {
    }
}