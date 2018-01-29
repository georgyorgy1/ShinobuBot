using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Shinobu.Services;

namespace Shinobu.Modules
{
    public class OwnerModule : ModuleBase<SocketCommandContext>
    {
        DiscordSocketClient _client;

        public OwnerModule(DiscordSocketClient _client)
        {
            this._client = _client;
        }

        [Command("kill")]
        public async Task Kill() 
        {
            if (Context.User.Id.ToString() == new JsonStringService().BuildConfig()["owner"])
            {
                await ReplyAsync("Shinobu is now shutting down. Please wait...");
                ShinobuLoggerService.Log("Bot was called to shut-down.");
                Environment.Exit(0);
            }
        }

        [Command("mindtrick")]
        public async Task MindTrick(ulong channelId, params string[] args)
        {
            if (Context.User.Id.ToString() == new JsonStringService().BuildConfig()["owner"])
            {
                string reply = string.Join(" ", args);
                var channel = _client.GetChannel(channelId) as IMessageChannel;
                await channel.SendMessageAsync(reply);
            }
        }
    }
}