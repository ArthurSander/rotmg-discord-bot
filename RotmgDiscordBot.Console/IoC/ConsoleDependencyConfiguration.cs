using Microsoft.Extensions.DependencyInjection;
using RotmgDiscordBot.ConsoleWorker.Settings;
using RotmgDiscordBot.Shared.Models.Configurations;

namespace RotmgDiscordBot.ConsoleWorker.IoC
{
    public static class ConsoleDependencyConfiguration
    {
        public static IServiceCollection ConfigureConsoleDependencies(this IServiceCollection services)
        {
            var appSettings = new ConsoleApplicationSettings();

            services.AddSingleton<IApplicationSettings, ConsoleApplicationSettings>((sp) => appSettings);
            services.AddScoped<Main>();
            return services;
        }
    }
}
