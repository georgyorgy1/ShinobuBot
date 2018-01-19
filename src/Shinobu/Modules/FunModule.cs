using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Shinobu.Services;

namespace Shinobu.Modules
{
    public class FunModule : ModuleBase<SocketCommandContext>
    {
        [Command("flip")]
        public async Task Flip() 
        {
            int coin = new Random().Next(0, 2);
            string faith = "";

            if (coin == 0)
            {
                faith = "heads";
            }

            else
            {
                faith = "tails";
            }

            await ReplyAsync("You got " + faith + "!");
        }

        [Command("palindrome")]
        public async Task Palindrome(string arg)
        {
            char[] charArray = arg.ToCharArray();
            Array.Reverse(charArray);
            string reverseString = new string(charArray);

            if (arg == reverseString)
            {
                await ReplyAsync("It's a palindrome");
            }

            else
            {
                await ReplyAsync("It's not a palindrome");
            }
        }

        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync($"Pong! Your latency is: {(Context.Client as DiscordSocketClient).Latency} ms :ping_pong:");
        }
    }
}