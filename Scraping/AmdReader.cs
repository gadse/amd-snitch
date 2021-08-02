using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;

namespace Scraping {
    public class AmdReader : Reader {

        public bool ScrapeAvailability() {
            return true;
        }
        public double ScrapePrice() {
            return 42.0;
        }

    }
}