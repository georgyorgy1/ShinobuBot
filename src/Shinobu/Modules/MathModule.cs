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

        [Command("add")]
        public async Task Add(params int[] args)
        {
            int answer = 0;

            for (int i = 0; i < args.Length; i++)
            {
                answer = answer + args[i];
            }

            await ReplyAsync(answer.ToString());
        }
    }
}