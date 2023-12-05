﻿using Discord.WebSocket;

namespace RotmgDiscordBot.Domain.Teste
{
    public class DefaultTeste : ITeste
    {
        private readonly DiscordSocketClient _discordClient;

        public DefaultTeste(DiscordSocketClient discordClient)
        {
            _discordClient = discordClient;
        }

        public void Run()
        {
            _discordClient.MessageReceived += HandleCommandAsync;
            Console.WriteLine("Teste ok.");
        }

        private async Task HandleCommandAsync(SocketMessage message)
        {
            if(message == null) 
                return;

            if (message.Author.IsBot)
                return;

            Console.WriteLine($"Mensagem recebida! {message.Content}");
            await message.Channel?.SendMessageAsync($"Resposta: {message.Content}");
        }
    }
}
