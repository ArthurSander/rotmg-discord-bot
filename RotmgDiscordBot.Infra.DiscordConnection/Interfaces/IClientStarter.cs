using Discord.WebSocket;

namespace RotmgDiscordBot.Infra.DiscordConnection.Interfaces
{
    public interface IClientStarter
    {
        DiscordSocketClient Client { get; }
        Task StartAsync(CancellationToken cancellationToken = default);
        void Stop();
    }
}
