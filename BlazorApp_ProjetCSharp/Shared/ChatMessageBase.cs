using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_ProjetCSharp.Shared
{
    public abstract class ChatMessageBase
    {
        // généré au hasard au démarrage, l'objectif est de pouvoir identifier une application source unique
        // même si plusieurs instances d'une même appli  ont été installées sur un même serveur
        public Guid Id { get; set; }

        // e.g. "MailDispatcher", "EDI", "ECMXWS"
        public string ApplicationType { get; set; }

        // e.g. CAGA012
        public string Server { get; set; }

        public Version Version { get; set; }

        public DateTime TimeSent { get; set; } = DateTime.Now;

    }
}
