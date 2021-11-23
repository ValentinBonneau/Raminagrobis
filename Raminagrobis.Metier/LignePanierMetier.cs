using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.Metier
{
    class LignePanierMetier
    {
        public int IDRef { get; private set; }
        public int Quantite { get; private set; }
        public int IDPanier { get; private set; }

        public LignePanierMetier(int idRef, int quantite, int idPanier)
        {
            IDRef = idRef;
            Quantite = quantite;
            IDPanier = idPanier;
        }
        
    }
}
