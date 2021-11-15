using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Metier
{
    class LignePanierMetier
    {
        public string refs { get; private set; }
        public int Quantite { get; private set; }
        public int IDPanier { get; private set; }

        public LignePanierMetier(string reference, int quantite, int idPanier)
        {
            refs = reference;
            Quantite = quantite;
            IDPanier = idPanier;
        }
    }
}
