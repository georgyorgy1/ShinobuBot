using System;
using System.Threading.Tasks;
using Discord.Commands;
using Shinobu.Services;

namespace Shinobu.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("about")]
        public async Task About() 
        {
            string botName = "ShinobuBot .NET Edition" + "\n";
            string author = "Author: Darth Squidward" + "\n";
            string buildString = "Build: " + new JsonStringService().BuildConfig()["build"] + "\n";
            string dotNetVersion = "DotNET Version: " + Environment.Version.ToString() + "\n";
            string shard = "Shard: What the bloody hell is a shard?";
            string finalString = botName + author + buildString + dotNetVersion + shard;
            await ReplyAsync(finalString);
        }

        [Command("help")]
        public async Task Help()
        {
            TextStringService infoFetcher = new TextStringService();
            string helpInfo = infoFetcher.Fetch("help.txt");
            await ReplyAsync(helpInfo);
        }
    }
}
