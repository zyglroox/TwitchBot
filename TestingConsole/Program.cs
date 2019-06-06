using System;
using TwitchBot.Models;

namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new TwitchBot.Models.TwitchBot();
            try
            {
                Console.WriteLine("Starting bot....");

                bot.Connect();

                Console.WriteLine("Bot connected!");

                Console.ReadLine();
            }
            finally
            {
                bot.Disconnect();
            }
        }
    }
}
