using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class NoEntryException : Exception
    {
        public Tables Table { get; private set; }
        public NoEntryException(string message, Tables table) : base(message) 
        {
            Table = table;
        } 
    }

    public enum Tables
    {
        Adherent, AssoRefFour, Fournisseur, LignePanier, LignePanierGlobal, Panier, PanierGlobal, Prix, Reference
    }
}
