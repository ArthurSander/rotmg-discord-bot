using Discord.WebSocket;

namespace RotmgDiscordBot.Infra.DiscordConnection.Interfaces
{
    public interface IClientStarter
    {
        DiscordSocketClient Client { get; }
        Task StartAsync();
        void Stop();
    }
}
