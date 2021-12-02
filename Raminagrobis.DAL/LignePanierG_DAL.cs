using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class LignePanierG_DAL
    {

        public int ID { get; set; }
        public int IDPanierG { get; set; }
        public int IDRef{ get; private set; }
        public int Quantite{ get; private set; }
        public Reference_DAL Refs { get; private set; }
        public PanierGlobal_DAL PanG { get; private set; }

        public LignePanierG_DAL(int id, int idPanierG, int idReference, int quantite)
            => (ID, IDPanierG, IDRef, Quantite) = (id, idPanierG, idReference, quantite);
        public LignePanierG_DAL(int idPanierG, int idReference, int quantite)
            => (IDPanierG, IDRef, Quantite) = (idPanierG, idReference, quantite);
        public LignePanierG_DAL(int id, PanierGlobal_DAL panG, Reference_DAL references)
           => (ID, PanG, Refs, IDPanierG, IDRef) = (id, panG, references, panG.ID, references.ID);



    }
}
