using System;
using System.IO;

using Reaction;
using Scraping;

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
                new DiscordNotificator(config, "TEST CARD"),
                new AmdReader()
            );

            scraper.ScrapeAndReact();

        }
    }
}
