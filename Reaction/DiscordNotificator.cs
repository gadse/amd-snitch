using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks; 

namespace Reaction {

    internal class DiscordNotificator : Reactor, IDisposable {
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
        public void react(string comment = "") {
            SendMessage(comment + "Test");
        }

        public void SendMessage(string content)
            {
                discordValues.Add("username", UserName);
                discordValues.Add("content", content);

                if (ProfilePicture != null) {
                    discordValues.Add("avatar_url", ProfilePicture);
                }
    
                dWebClient.UploadValues(WebHook, discordValues);
            }
    
        public void Dispose()
        {
            dWebClient.Dispose();
        }
    }
}