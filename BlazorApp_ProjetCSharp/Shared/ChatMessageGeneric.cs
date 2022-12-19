using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_ProjetCSharp.Shared
{
    public class ChatMessageGeneric: ChatMessageBase
    {
        public string MessageType { get; set; }
        public int MessageVersion { get; set; }
        public string Message { get; set; }

        public ChatMessageGeneric()
        {
        }

        public ChatMessageGeneric(Guid Id, string ApplicationType, string Server, Version Version, string MessageType, int MessageVersion, string Message)
        {
            this.Id = Id;
            this.ApplicationType = ApplicationType;
            this.Server = Server;
            this.Version = Version;
            this.MessageType = MessageType;
            this.MessageVersion = MessageVersion;
            this.Message = Message;
        }
    }
}
