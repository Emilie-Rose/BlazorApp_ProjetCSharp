using Microsoft.AspNetCore.SignalR;

namespace BlazorApp2.Server
{
    public class Tchat:Hub<ITchat>
    {
        public async Task SendMessage(string username, string message)
        {
            await Clients.All.ReceiveMessage(username, message);
        }
    }

}
