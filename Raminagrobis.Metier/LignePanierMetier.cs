using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.Metier
{
    public class LignePanierMetier
    {
        public string refs { get; private set; }
        public int Quantite { get; private set; }
        public int IDPanier { get; private set; }
        public int IDrefs { get; private set; }
        public LignePanierMetier(string reference, int quantite, int idPanier)
        {
            refs = reference;
            Quantite = quantite;
            IDPanier = idPanier;
        }
        public LignePanierMetier(int idref, int quantite, int idPanier)
        {
            IDrefs = idref;
            Quantite = quantite;
            IDPanier = idPanier;
        }

    }
}
