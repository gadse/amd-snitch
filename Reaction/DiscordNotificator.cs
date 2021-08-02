using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks; 

namespace Reaction {

    internal class DiscordNotificator : Reactor, IDisposable {
        public string ItemName { get; }

        private readonly WebClient dWebClient;
        private NameValueCollection discordValues = new NameValueCollection();
        public string WebHook { get; set;}
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }

        public DiscordNotificator(Config config) {
            this.dWebClient = new WebClient();
            this.WebHook = config.NotificationTarget;
            this.UserName = "AMD Snitch";
            this.ProfilePicture = null;
        }

        public DiscordNotificator(Config config, string itemName) : this(config) {
            this.ItemName = itemName;
        }

        public void react(params string[] lines) {
            var message = $"{ItemName} available!\n";
            message += String.Join("\n", lines);
            SendMessage(message);
        }

        public void SendMessage(string content) {
            Console.WriteLine("Informing Discord...");
            discordValues.Add("username", UserName);
            discordValues.Add("content", content);

            if (ProfilePicture != null) {
                discordValues.Add("avatar_url", ProfilePicture);
            }
    
            dWebClient.UploadValues(WebHook, discordValues);
        }
    
        public void Dispose() {
            dWebClient.Dispose();
        }
    }
}