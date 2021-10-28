using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Panier_DAL
    {
        public int ID { get; private set; }
        public int IDAdherent { get; private set; }
        public int IDPanierG { get; private set; }

        public Adherent_DAL Adherent { get; private set; }

        public List<LignePanier_DAL> Lignes { get; private set; }

        public Panier_DAL(IEnumerable<LignePanier_DAL> desLignes) => (Lignes) = (desLignes.ToList());

        public Panier_DAL(int id, int idAdherent, int idPanierG, Adherent_DAL adherent, IEnumerable<LignePanier_DAL> desLignes)
            => (ID, IDAdherent, IDPanierG, Adherent, Lignes) = (id, idAdherent, idPanierG, adherent, desLignes.ToList());
    }
}
