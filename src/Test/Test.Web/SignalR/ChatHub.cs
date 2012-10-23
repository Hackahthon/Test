using System.Web;
using Microsoft.Web.WebPages.OAuth;
using SignalR.Hubs;

namespace Test.Web.SignalR
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        public void Join()
        {
            var name = GetUsername();
            Clients.onJoined(name);
        }

        public void Message(string message)
        {
            var user = GetUsername();
            Clients.onMessage(user, message);
        }

        private string GetUsername()
        {
            if(OAuthWebSecurity.IsAuthenticatedWithOAuth)
                
            return HttpContext.Current.User.Identity.Name;
        }
    }
}