using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Metier
{
    class PanierMetier
    {
        public int IDAdherent { get; private set; }
        public int IDPanierG { get; private set; }

        public List<LignePanierMetier> lignes { get; private set; }


        public PanierMetier(int idAdherent, int idPanierG, List<LignePanierMetier> ligne)
        {
            IDAdherent = idAdherent;
            IDPanierG = idPanierG;
            lignes = ligne;
        } 

        public void ajouterLigne(string refs, int quantite, int id)
        {
            LignePanierMetier ligne = new LignePanierMetier(refs, quantite, id );
            lignes.Add(ligne);
        }

        public List<LignePanierMetier> getLigne()
        {
            return lignes;
        }
    }
}
