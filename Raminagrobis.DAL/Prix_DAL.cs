using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Prix_DAL
    {
        public int IDLignePanierG { get; private set; }
        public int IDFournisseur { get; private set; }
        public int Prix { get; private set; }
        public LignePanierG_DAL LignesG { get; private set; }
        public Fournisseur_DAL Fours { get; private set; }

        public Prix_DAL(int idLignePanierG, int idFournisseur, int prix)
            => (IDLignePanierG, IDFournisseur, Prix) = (idLignePanierG, idFournisseur, prix);
        public Prix_DAL(LignePanierG_DAL lignesG, Fournisseur_DAL fours, int prix)
            => (LignesG, Fours, Prix) = (lignesG, fours, prix);

    }
}
