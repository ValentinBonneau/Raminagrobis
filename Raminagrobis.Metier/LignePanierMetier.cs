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
        public string Refs { get; private set; }
        public int Quantite { get; private set; }
        public int IDPanier { get; private set; }
        public int IDrefs { get; private set; }
        public double PrixU { get; private set; }
        public LignePanierMetier(int idref, int quantite, double prixU, int idPanier)
        {
            var depot = new ReferenceDepot_DAL();
            IDrefs = idref;
            Quantite = quantite;
            IDPanier = idPanier;
            PrixU = prixU;
            Refs = depot.GetByID(idref).Reference;
        }
    }
}
