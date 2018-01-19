using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Shinobu.Services;

namespace Shinobu.Modules
{
    public class OwnerModule : ModuleBase<SocketCommandContext>
    {
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
    }
}