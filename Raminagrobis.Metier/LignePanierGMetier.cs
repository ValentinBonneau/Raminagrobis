using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.Metier
{
    public class LignePanierGMetier
    {
        public int ID { get; set; }
        public int IDPanierG { get; private set; }
        public int Quantite { get; set; }
        public string refs { get; private set; } 
        public int IDrefs { get; private set; }

        public LignePanierGMetier(int id,int idPanierG, int quantite, string reference)
        {
            ID = id;
            IDPanierG = idPanierG;
            Quantite = quantite;
            refs = reference;
            var depot = new ReferenceDepot_DAL();
            IDrefs = depot.GetByRef(refs).ID;
        }
        public LignePanierGMetier(int id, int idPanierG, int quantite, int idref)
        {
            ID = id;
            IDPanierG = idPanierG;
            Quantite = quantite;
            IDrefs = idref;
            var depot = new ReferenceDepot_DAL();
            refs = depot.GetByID(idref).Reference; 
        }
    }
}
