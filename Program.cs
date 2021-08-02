using System;
using System.IO;

using Reaction;

namespace AmdSnitch
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new Config();

            foreach (var x in config.UrlsToWatch) {
                Console.WriteLine(x);
            }

            var scraper = new Scraper(
                new AmdReader()
            )

            var notificator = new DiscordNotificator(config);
            notificator.react("Test");
        }
    }
}
