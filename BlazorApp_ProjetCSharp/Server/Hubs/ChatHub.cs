using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.ResponseCompression;
using BlazorServerSignalRApp.Server.Hubs;

namespace BlazorServerSignalRApp.Server.Hubs
{
/*    public class Tchat:Hub<ChatHub>
    {
        public async Task SendMessage(string userInput, string messageInput)
        {
            await Clients.All.SendAsync("ReceiveMessage", userInput, messageInput);
        }
    }
*/
    public class ChatHub : Hub
            {
        public async Task SendMessage(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }
    }
}