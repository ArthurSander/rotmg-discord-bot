using Discord;
using Discord.WebSocket;
using RotmgDiscordBot.Infra.DiscordConnection.Interfaces;
using RotmgDiscordBot.Shared.Models.Configurations;

namespace RotmgDiscordBot.Infra.DiscordConnection
{
    public class ClientStarter : IClientStarter
    {
        private readonly IApplicationSettings _settings;
        private bool _running;

        public ClientStarter(IApplicationSettings settings)
        {
            _settings = settings;
            _running = true;
        }

        public DiscordSocketClient Client { get; private set; }

        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            if (await StopIfCancellationRequested(cancellationToken))
                return;

            if(Client != null)
                return;

            var client = new DiscordSocketClient(createNewConfig());

            client.Log += LogConsole;

            if (await StopIfCancellationRequested(cancellationToken))
                return;

            await client.LoginAsync(TokenType.Bot, _settings.BotToken);
            await client.StartAsync();

            Client = client;

            while (_running)
            {
                if (await StopIfCancellationRequested(cancellationToken))
                    return;

                await Task.Delay(1000);
            }
            return;
        }

        public void Stop()
        {
            _running = false;
        }

        private Task LogConsole(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        private DiscordSocketConfig createNewConfig()
        {
            var config = new DiscordSocketConfig()
            {
                GatewayIntents = GatewayIntents.All
            };

            return config;
        }

        private async Task<bool> StopIfCancellationRequested(CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
                return false;

            Stop();
            await Client.LogoutAsync();
            await Client.DisposeAsync();

            return true;
        }
    }
}
