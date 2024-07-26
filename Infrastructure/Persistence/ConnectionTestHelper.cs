using Npgsql;

namespace Persistence
{
    public static class ConnectionTestHelper
    {
        public static async Task<bool> TestDb()
        {
            //var connectionString = "Username=testUser;Password=123456;Host=localhost;Port=5432;Database=NotificationDb;";
            var connectionString = Configuration.ConnectionString;
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    Console.WriteLine("Database connection successful.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection failed: {ex.Message}");
                return false;
            }
        }
    }
}
