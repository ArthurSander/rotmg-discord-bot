using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RotmgDiscordBot.Infra.DiscordConnection;
using RotmgDiscordBot.Infra.DiscordConnection.Interfaces;
using RotmgDiscordBot.Shared.Models.Configurations;

namespace RotmgDiscordBot.ConsoleWorker.IoC
{
    public static class ConsoleDependencyConfiguration
    {
        public static IServiceCollection ConfigureConsoleDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IApplicationSettings, DefaultApplicationSettings>((sp) => getAppSettings())
                .AddScoped<Main>()
                .ConfigureDiscordConnection();

            return services;
        }

        private static DefaultApplicationSettings getAppSettings()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            return config.GetSection("Settings").Get<DefaultApplicationSettings>();
        }

        private static IServiceCollection ConfigureDiscordConnection(this IServiceCollection services)
        {
            services.AddSingleton<IClientStarter, ClientStarter>();
            var sp = services.BuildServiceProvider();
            var clientStarter = sp.GetRequiredService<IClientStarter>();
            clientStarter.StartAsync();

            while (clientStarter.Client == null)
                Thread.Sleep(1000);

            services.AddSingleton(clientStarter.Client);
            return services;
        }
    }
}
