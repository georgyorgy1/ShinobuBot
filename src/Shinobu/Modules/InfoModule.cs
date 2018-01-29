using System;
using System.Diagnostics;
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
            //Get current memory usage
            Process currentProcess = Process.GetCurrentProcess();
            float memory = (float) currentProcess.WorkingSet64 / 1048576;

            //put actual information
            string botName = "ShinobuBot" + "\n";
            string author = "Author: Darth Squidward" + "\n";
            string buildString = "Build: " + new JsonStringService().BuildConfig()["build"] + "\n";
            string dotNetVersion = "DotNET Version: " + Environment.Version.ToString() + "\n";
            string memoryUsage = "Memory: " + memory.ToString("0.00") + " MB" + "\n";
            string shard = "Shard: What the bloody hell is a shard?";

            //Send message
            string finalString = botName + author + buildString + dotNetVersion + memoryUsage + shard;
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
