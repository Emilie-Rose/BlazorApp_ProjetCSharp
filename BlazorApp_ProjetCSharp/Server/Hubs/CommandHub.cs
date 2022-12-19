using BlazorApp_ProjetCSharp.Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerSignalRApp.Server.Hubs
{
    public class CommandHub : Hub<ICommandClient>
    {
        static Dictionary<string, ChatMessageInscription> inscrits = new Dictionary<string, ChatMessageInscription>();
        public static CommandHub commandHub;

        public CommandHub()
        {
            CommandHub.commandHub = this;
        }

        public async Task SendMessage(string username, string message)
        {
            await Clients.All.ReceiveMessage(username, message);
        }
        public async Task SendGenericMessage(ChatMessageGeneric message)
        {
            await Clients.All.ReceiveGenericMessage(message);
        }

        public async Task SendGenericMessageToGroup(string group, ChatMessageGeneric message)
        {
            await Clients.Group(group).ReceiveGenericMessage(message);
        }
        public async Task SendGenericMessageToId(Guid[] inscritsGuids, ChatMessageGeneric message)
        {
            List<string> connectionIds = new List<string>(inscritsGuids.Length);
            lock (inscrits)
            {
                foreach (string connectionId in inscrits.Keys)
                {
                    if (inscritsGuids.Contains(inscrits[connectionId].Id))
                    {
                        connectionIds.Add(connectionId);
                    }
                }
            }

            await Clients.Clients(connectionIds).ReceiveGenericMessage(message);
        }


        public async Task Inscription(ChatMessageInscription message)
        {
            lock (inscrits)
            {
                if (inscrits.ContainsKey(Context.ConnectionId))
                    inscrits.Remove(Context.ConnectionId);
                inscrits.Add(Context.ConnectionId, message);
            }
            await Groups.AddToGroupAsync(Context.ConnectionId, message.ApplicationType);
            await Clients.Group("Admin").ReceiveInscriptionMessage(message);

        }

        public async Task GetInscrits()
        {

            ChatMessageInscription[] inscriptions = null;
            lock (inscrits)
            {
                inscriptions = inscrits.Values.ToArray();
            }

            await Clients.Caller.ReceiveAllInscriptions(inscriptions);

        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
    }
}
