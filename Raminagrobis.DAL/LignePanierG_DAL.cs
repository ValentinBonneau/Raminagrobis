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
        public string Ref{ get; private set; }
        public int Quantite{ get; private set; }
        public Reference_DAL Refs { get; private set; }
        public PanierGlobal_DAL PanG { get; private set; }

        public LignePanierG_DAL(int id, int idPanierG, string reference, int quantite)
            => (ID, IDPanierG, Ref, Quantite) = (id, idPanierG, reference, quantite);
        public LignePanierG_DAL(int idPanierG, string reference, int quantite)
            => (IDPanierG, Ref, Quantite) = (idPanierG, reference, quantite);
        public LignePanierG_DAL(int id, PanierGlobal_DAL panG, Reference_DAL references)
           => (ID, PanG, Refs, IDPanierG, Ref) = (id, panG, references, panG.ID, references.ID.ToString());



    }
}
