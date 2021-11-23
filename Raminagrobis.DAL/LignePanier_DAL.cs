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
        public string Ref { get; private set; }
        public int Quantite { get; private set; }
        public int IDPanier { get; set; }

        public Reference_DAL Refs { get; private set; }
        public Panier_DAL Pan { get; private set; }

        public LignePanier_DAL(int id, string Ref, int quantite, int idPanier)
            => (ID, IDPanier, Quantite, Ref) = (id, idPanier, quantite, Ref);
        public LignePanier_DAL(string Ref, int quantite, int idPanier)
            => (IDPanier, Quantite, Ref) = (quantite, idPanier, Ref);
        public LignePanier_DAL(int id, Reference_DAL refs, int quantite, Panier_DAL pans)
            => (ID, Refs, Quantite, Pan) = (id, refs, quantite, pans);
    }
}
