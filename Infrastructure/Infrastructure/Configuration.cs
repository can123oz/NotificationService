using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public static class Configuration
    {
        public static string ActiveSmsProvider
        {
            get
            {
                ConfigurationManager configuration = new();
                if (Environment.GetEnvironmentVariable("BASE_PATH") is not null)
                {
                    var basePath = Directory.GetCurrentDirectory();
                    configuration.SetBasePath(basePath);
                    configuration.AddJsonFile("appsettings.json");
                }
                else
                {
                    configuration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Api"));
                    configuration.AddJsonFile("appsettings.json");
                }
                return configuration.GetSection("Sms:ActiveProvider").Value ?? "TODO";
            }
        }

        public static string GetSenderMail
        {
            get
            {
                ConfigurationManager configuration = new();
                if (Environment.GetEnvironmentVariable("BASE_PATH") is not null)
                {
                    var basePath = Directory.GetCurrentDirectory();
                    configuration.SetBasePath(basePath);
                    configuration.AddJsonFile("appsettings.json");
                }
                else
                {
                    configuration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Api"));
                    configuration.AddJsonFile("appsettings.json");
                }
                return configuration.GetSection("EMAIL:Mail").Value ?? "TODO";
            }
        }

        public static string GetEmailPassword
        {
            get
            {
                ConfigurationManager configuration = new();
                if (Environment.GetEnvironmentVariable("BASE_PATH") is not null)
                {
                    var basePath = Directory.GetCurrentDirectory();
                    configuration.SetBasePath(basePath);
                    configuration.AddJsonFile("appsettings.json");
                }
                else
                {
                    configuration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Api"));
                    configuration.AddJsonFile("appsettings.json");
                }

                return configuration.GetSection("EMAIL:Password").Value ?? "TODO";
            }
        }

        public static bool IsNotificationTypeActive(string notificationType)
        {
            ConfigurationManager configuration = new();
            if (Environment.GetEnvironmentVariable("BASE_PATH") is not null)
            {
                var basePath = Directory.GetCurrentDirectory();
                configuration.SetBasePath(basePath);
                configuration.AddJsonFile("appsettings.json");
            }
            else
            {
                configuration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Api"));
                configuration.AddJsonFile("appsettings.json");
            }
            string isActiveString = configuration.GetSection($"{notificationType}:IsNotificationTypeActive").Value ?? "false";
            bool isActive;
            bool success = bool.TryParse(isActiveString, out isActive);
            if (!success)
            {
                isActive = false;
            }
            return isActive;
        }

        public static string NotificationProvider(string notificationType)
        {
            ConfigurationManager configuration = new();
            if (Environment.GetEnvironmentVariable("BASE_PATH") is not null)
            {
                var basePath = Directory.GetCurrentDirectory();

                configuration.SetBasePath(basePath);
                configuration.AddJsonFile("appsettings.json");
            }
            else
            {
                configuration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Api"));
                configuration.AddJsonFile("appsettings.json");
            }
            return configuration.GetSection($"{notificationType}:ActiveProvider").Value ?? "Amazon";
        }
    }
}