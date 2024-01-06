
using Discord;
using Discord.WebSocket;

namespace DiscordBotTestConsole
{
   

  
    public class Program
    {
        private DiscordSocketClient _client;
        private string _token = "";
        private SocketUser _neko;
        static void Main(string[] args)
          => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {
            var config = new DiscordSocketConfig()
            {
                GatewayIntents = GatewayIntents.MessageContent | GatewayIntents.GuildMessages | GatewayIntents.Guilds | GatewayIntents.GuildMembers,
               

            };
            _client = new DiscordSocketClient(config);
            _client.Log += Log;

            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();
             

            _client.MessageReceived += MessageReceived;
            _client.Ready += ReadyAsync;

            // Keep the program running
            await Task.Delay(-1);
        }
        private  Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        private async Task MessageReceived(SocketMessage message)
        {

            if (message.Content == "!hello")
            {
                await message.Channel.SendMessageAsync("@.neko_oke. TI JOPA!");
            }
            if (message.Content == "сам")
            {
                await message.Channel.SendMessageAsync("нет это ти сам!");
            }
            if (message.Content == "ти ти")
            {
                await message.Channel.SendMessageAsync("сам сам");
            }
            if(message.Content == "!all-users")
            {
                ulong serverId = (message.Channel as SocketGuildChannel)?.Guild.Id ?? 0;
                var guild = _client.GetGuild(serverId);

                if (guild != null)
                {
                    // Get all users in the guild
                    var users = guild.Users.ToList();

                    // Output usernames of users in the guild
                    foreach (var user in users)
                    {
                        await message.Channel.SendMessageAsync($"User: {user.Username}#{user.Discriminator}");
                    }
                }
            }
            if (message.Content == "!channel_users")
            {
                ulong channelId = message.Channel.Id;
                var channel = _client.GetChannel(channelId);
                var members = channel.Users.ToList();
                foreach (var member in members)
                {
                  await message.Channel.SendMessageAsync($"User: {member.Username}#{member.Discriminator}");
                }
                //await message.Channel.SendMessageAsync($"Зайка ти жопка, {_neko.Mention}!");
            }


        }
        private async Task ReadyAsync()
        {
         
        
        }
    }
}