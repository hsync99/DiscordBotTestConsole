
using Discord;
using Discord.WebSocket;

namespace DiscordBotTestConsole
{
   

  
    internal class Program
    {
        private DiscordSocketClient _client;
        private string _token = "MTE5MDk5MTU4NDg4ODYzMTM2Nw.GUU3ZY.JMYdE-ZbCXiLXHH_wLz-cw_mgbs5dQRjzi1M8Y";
        static void Main(string[] args)
          => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;

            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();

            _client.MessageReceived += MessageReceived;

            // Keep the program running
            await Task.Delay(-1);
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Content == "!hello")
            {
                await message.Channel.SendMessageAsync("Hello!");
            }
        }
    }
}