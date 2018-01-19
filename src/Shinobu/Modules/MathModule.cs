using System;
using System.Threading.Tasks;
using Discord.Commands;
using Shinobu.Services;

namespace Shinobu.Modules
{
    public class MathModule : ModuleBase<SocketCommandContext>
    {
        [Command("random")]
        public async Task Random()
        {
            int randomNumber = new Random().Next(0, 2147483646);
            await ReplyAsync(randomNumber.ToString());
        }
    }
}