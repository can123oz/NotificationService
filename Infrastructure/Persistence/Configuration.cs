using Microsoft.Extensions.Configuration;
using Persistence.QueueConsumer;

namespace Persistence
{
    static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configuration = new();
                if (Environment.GetEnvironmentVariable("BASE_PATH") is not null)
                {
                    var basePath = Directory.GetCurrentDirectory();
                    configuration.SetBasePath(basePath);
                    configuration.AddJsonFile("appsettings.Development.json");
                }
                else
                {
                    configuration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Api"));
                    configuration.AddJsonFile("appsettings.json");
                }
                return configuration.GetConnectionString("PostgreSQL") ?? "TODO";
            }
        }

        public static RabbitMqConfig GetRabbitMqConfig
        {
            get
            {
                ConfigurationManager configuration = new();
                if (Environment.GetEnvironmentVariable("BASE_PATH") is not null)
                {
                    var basePath = Directory.GetCurrentDirectory();
                    //configuration.SetBasePath(Path.Combine(basePath, Environment.GetEnvironmentVariable("BASE_PATH")!));
                    configuration.SetBasePath("/app");
                    configuration.AddJsonFile("appsettings.Development.json");
                }
                else
                {
                    configuration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Api"));
                    configuration.AddJsonFile("appsettings.json");
                }
                string? userName = configuration.GetSection("RabbitMQ:UserName").Value;
                string? password = configuration.GetSection("RabbitMQ:Password").Value;
                string? hostName = configuration.GetSection("RabbitMQ:HostName").Value;
                return new RabbitMqConfig(userName,password,hostName);
            }
        }
    }
}