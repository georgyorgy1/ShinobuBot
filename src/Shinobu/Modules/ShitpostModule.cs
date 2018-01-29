using System;
using System.Threading.Tasks;
using Discord.Commands;
using Shinobu.Services;

namespace Shinobu.Modules
{
    public class ShitpostModule : ModuleBase<SocketCommandContext>
    {
        [Command("checkem")]
        public async Task CheckEm(params string[] args) 
        {
            string number =  new Random().Next(100000000, 999999999).ToString();
            await ReplyAsync("Check em!" + "\n" + "Your number: " + number);
        }

        [Command("currentyear")]
        public async Task CurrentYear(params string[] args)
        {
            await ReplyAsync(">" + string.Join(" ", args) + " in the current year");
        }
    }
}