using RotmgDiscordBot.Domain.Teste;
using RotmgDiscordBot.Shared.Models.Configurations;

namespace RotmgDiscordBot.ConsoleWorker
{
    public class Main
    {
        private readonly ITeste _teste;
        private readonly IApplicationSettings _settings;
        private bool _running;

        public Main(ITeste teste, IApplicationSettings settings)
        {
            _teste = teste;
            _settings = settings;
        }

        public async Task RunAsync()
        {
            _running = true;
            _teste.Run();

            while (_running)
                await Task.Delay(1000);

            Console.WriteLine($"Bot {_settings.BotName} shutting down.");
        }
    }
}
