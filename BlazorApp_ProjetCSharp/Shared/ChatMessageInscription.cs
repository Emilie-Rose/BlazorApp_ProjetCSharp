using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_ProjetCSharp.Shared
{
    public class ChatMessageInscription: ChatMessageBase
    {
        public ChatMessageInscription(Guid Id, string ApplicationType, string Server, Version Version)
        {
            this.Id = Id;
            this.ApplicationType = ApplicationType;
            this.Server = Server;
            this.Version = Version;
        }
    }
}
