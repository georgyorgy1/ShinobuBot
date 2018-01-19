using System;
using System.Threading.Tasks;
using Discord.Commands;
using Shinobu.Services;

namespace Shinobu.Modules
{
    public class ShitpostModule : ModuleBase<SocketCommandContext>
    {
        [Command("checkem")]
        public async Task CheckEm() 
        {
            string number =  new Random().Next(100000000, 999999999).ToString();
            await ReplyAsync("Check em!" + "\n" + "Your number: " + number);
        }
    }
}