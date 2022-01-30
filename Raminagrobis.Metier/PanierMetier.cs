using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.Metier
{
    public class PanierMetier
    {
        public int ID { get; private set; }
        public int IDAdherent { get; private set; }
        public int IDPanierG { get; private set; }
        public List<LignePanierMetier> Lignes { get; private set; }


        public PanierMetier(int id, int idAdherent, int idPanierG, List<LignePanierMetier> ligne)

        {
            ID = id;
            IDAdherent = idAdherent;
            IDPanierG = idPanierG;
            Lignes = ligne;
        }

        public void Ajouter_Ligne(LignePanierMetier ligne)
        {
            Lignes.Add(ligne);
        }
       
    }
}
