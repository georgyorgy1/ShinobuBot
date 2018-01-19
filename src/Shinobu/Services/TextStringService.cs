using System;
using System.IO;
using Discord;

namespace Shinobu.Services
{
    public class TextStringService
    {
        public string fileString;

        public string Fetch(string fileName)
        {
            try
            {
                foreach (string line in File.ReadLines("Files/" + fileName))
                {
                    fileString = fileString + line + "\n";
                }

                return fileString;
            }

            catch (System.Exception ex)
            {
                ShinobuLoggerService.Log(ex.ToString());
                throw;
            }
        }
    }
}