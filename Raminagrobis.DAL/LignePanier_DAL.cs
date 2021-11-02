using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class LignePanier_DAL
    {

        public int ID { get; set; }
        public int IDRef { get; private set; }
        public int Quantite { get; private set; }
        public int IDPanier { get; private set; }

        public Reference_DAL Refs { get; private set; }
        public Panier_DAL Pan { get; private set; }

        public LignePanier_DAL(int id, int idRef, int quantite, int idPanier)
            => (ID, IDPanier, Quantite, IDRef) = (id, idRef, quantite, idPanier);
        public LignePanier_DAL(int id, Reference_DAL refs, int quantite, Panier_DAL pans)
            => (ID, Refs, Quantite, Pan) = (id, refs, quantite, pans);
    }
}
