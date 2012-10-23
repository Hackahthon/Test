using System.Web;
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

        private static string GetUsername()
        {
            return HttpContext.Current.User.Identity.Name;
        }
    }
}