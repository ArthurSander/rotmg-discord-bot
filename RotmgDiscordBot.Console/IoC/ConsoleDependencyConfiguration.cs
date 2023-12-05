using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RotmgDiscordBot.ConsoleWorker.Settings;
using RotmgDiscordBot.Shared.Models.Configurations;

namespace RotmgDiscordBot.ConsoleWorker.IoC
{
    public static class ConsoleDependencyConfiguration
    {
        public static IServiceCollection ConfigureConsoleDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IApplicationSettings, ConsoleApplicationSettings>((sp) => getAppSettings());
            services.AddScoped<Main>();
            return services;
        }

        private static ConsoleApplicationSettings getAppSettings()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            return config.GetSection("Settings").Get<ConsoleApplicationSettings>();
        }
    }
}
