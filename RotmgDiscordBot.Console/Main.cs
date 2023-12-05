using RotmgDiscordBot.Domain.Teste;
using RotmgDiscordBot.Shared.Models.Configurations;

namespace RotmgDiscordBot.ConsoleWorker
{
    public class Main
    {
        private readonly ITeste _teste;
        private readonly IApplicationSettings _settings;

        public Main(ITeste teste, IApplicationSettings settings)
        {
            _teste = teste;
            _settings = settings;
        }

        public async Task RunAsync()
        {
            _teste.Run();
            Console.WriteLine($"Bot {_settings.BotName} shutting down.");
        }
    }
}
