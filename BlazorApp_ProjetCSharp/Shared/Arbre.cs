using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_ProjetCSharp.Shared
{
    internal abstract class Arbre
    {
        // Attributs arbre
        private readonly int IdArbre;
        private double Position;
        private int LargeurTronc;
        private int HauteurTronc;
        private int LargeurFeuille;
        private int HauteurFeuille;
    }
}
