namespace Scraper {
    
    internal class Scraper {
        public bool Available => Reader.ScrapeAvailability();
        public double Price => Reader.ScrapePrice();

        public Reactor reactor { get; }
        public Reader reader { get; }

        public Scraper(Reactor reactor, Reader reader) {
            this.reactor = reactor;
            this.reader = reader;
        }

    }

}

