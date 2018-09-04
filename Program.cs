using System;
using System.Threading.Tasks;

using Discord;
using Discord.WebSocket;

namespace Trinibot
{
    class Program
    {
        DiscordSocketClient Client;
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            Client = new DiscordSocketClient();

            Client.Log += Log;
            Client.MessageReceived += OnMessageReceived;
            //Client.ReactionAdded += OnReaction;

            string token = "NDg2MjQ4NTcyMTc4NjYxMzg4.Dm80gg.I4ZtgYoFCHJNQXBExR16JaJdcuo";
            await Client.LoginAsync(TokenType.Bot, token);
            await Client.StartAsync();

            await Task.Delay(-1);
        }
        private Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }

        private async Task OnMessageReceived(SocketMessage message)
        {
            if (message.Content == "!Trinity")
            {
                await message.Channel.SendMessageAsync("Gloire à la sainte Trinité !");
            }
        }
    }
}
