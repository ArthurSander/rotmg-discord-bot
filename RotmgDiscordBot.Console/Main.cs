using Discord;
using Discord.WebSocket;
using RotmgDiscordBot.Domain.Teste;
using RotmgDiscordBot.Infra.DiscordConnection.Interfaces;
using RotmgDiscordBot.Shared.Models.Configurations;

namespace RotmgDiscordBot.ConsoleWorker
{
    public class Main
    {
        private readonly ITeste _teste;
        private readonly IApplicationSettings _settings;
        private readonly DiscordSocketClient _client;

        private bool _running;

        public Main(ITeste teste, IApplicationSettings settings, DiscordSocketClient client)
        {
            _teste = teste;
            _settings = settings;
            _client = client;
        }

        public async Task RunAsync(CancellationToken cancellationToken = default)
        {
            _running = true;
            await _teste.Run(cancellationToken);

            // TODO: create global "running" state and Graceful Shutdown checks
            while (_running)
            {
                if (cancellationToken.IsCancellationRequested && _client.LoginState == LoginState.LoggedOut)
                    break;
                
                await Task.Delay(1000);
            }

            Console.WriteLine($"Bot {_settings.BotName} shutting down.");
        }
    }
}
