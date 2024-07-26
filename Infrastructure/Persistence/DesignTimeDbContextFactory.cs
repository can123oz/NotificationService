using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistence.Context;

namespace Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<NotificationServiceDbContext>
    {
        public NotificationServiceDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<NotificationServiceDbContext> contextOptionsBuilder = new();
            contextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            
            return new NotificationServiceDbContext(contextOptionsBuilder.Options);
        }
    }
}
