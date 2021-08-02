using System;

using Reaction;

namespace Scraping {
    
    internal class Scraper {
        public bool Available => Reader.ScrapeAvailability();
        public double Price => Reader.ScrapePrice();
        public string ItemName { get; }

        public Reactor Reactor { get; }
        public Reader Reader { get; }

        public Scraper(Reactor reactor, Reader reader) {
            this.Reactor = reactor;
            this.Reader = reader;
        }

        public Scraper(Reactor reactor, Reader reader, string itemName)
            : this(reactor, reader) {
            this.ItemName = itemName;
        }

        public bool ScrapeAndReact() {
            Console.WriteLine($"CHECKING {ItemName}");
            if (Available) {
                Console.WriteLine("`- availabie!");
                Reactor.react($"PRICE {Price}");
                return true;
            } else {
                return false;
            }
        }

    }

}

