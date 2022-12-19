using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_ProjetCSharp.Shared
{
    public interface ICommandClient
    {
        Task ReceiveMessage(string user, string message);
        Task ReceiveMessage(string message);

        Task ReceiveGenericMessage(ChatMessageGeneric message);
        Task ReceiveInscriptionMessage(ChatMessageInscription message);
        Task ReceiveAllInscriptions(ChatMessageInscription[] inscriptions);
    }
}
