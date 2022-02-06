using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.DAL
{
    public class LignePanier_DAL
    {

        public int ID { get; set; }
        public int IdRef { get; private set; }
        public int Quantite { get; private set; }
        public int IDPanier { get; set; }

        public Reference_DAL Refs { get; private set; }
        public Panier_DAL Pan { get; private set; }

        public LignePanier_DAL(int id, int reference, int quantite, int idPanier)
            => (ID, IDPanier, Quantite, IdRef) = (id, idPanier, quantite, reference);
        public LignePanier_DAL(int reference, int quantite, int idPanier)
            => (IDPanier, Quantite, IdRef) = (quantite, idPanier, reference);
        public LignePanier_DAL(int id, Reference_DAL refs, int quantite, Panier_DAL pans)
            => (ID, Refs, Quantite, Pan) = (id, refs, quantite, pans);
        public LignePanier_DAL(string reference, int quantite)
        {
            var depotRef = new ReferenceDepot_DAL();
            IdRef = depotRef.GetByRef(reference).ID;
            Quantite = quantite;
        }
        
    }
}
