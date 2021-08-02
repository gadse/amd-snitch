using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;

public class AmdReader : AbstractReader{

    public static bool ScrapeAvailability() {
        return true;
    }
    public static double ScrapePrice() {
        return 42.0;
    }

}