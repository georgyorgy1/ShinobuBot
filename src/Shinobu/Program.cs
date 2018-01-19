using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Shinobu.Services;

namespace Shinobu
{
    class Program
    {
        private DiscordSocketClient _client;
        private IConfiguration _config;

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _config = new JsonStringService().BuildConfig();

            var services = ConfigureServices();
            services.GetRequiredService<LogService>();

            await services.GetRequiredService<CommandHandlingService>().InitializeAsync(services);
            await _client.LoginAsync(TokenType.Bot, _config["token"]);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private IServiceProvider ConfigureServices()
        {
            return new ServiceCollection().AddSingleton(_client).AddSingleton<CommandService>().AddSingleton<CommandHandlingService>().AddLogging().AddSingleton<LogService>().AddSingleton(_config).BuildServiceProvider();
        }

        public static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }
    }
}