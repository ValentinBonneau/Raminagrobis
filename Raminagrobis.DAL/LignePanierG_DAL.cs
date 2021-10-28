using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class LignePanierG_DAL
    {

        public int ID { get; private set; }
        public int IDPanierG { get; private set; }
        public int IDRef{ get; private set; }
        public Reference_DAL Refs { get; private set; }
        public PanierGlobal_DAL PanG { get; private set; }

        public LignePanierG_DAL(int id, int idPanierG, int idRef)
            => (ID, IDPanierG, IDRef) = (id, idPanierG, idRef);
        public LignePanierG_DAL(int id, PanierGlobal_DAL panG, Reference_DAL refs)
           => (ID, PanG, Refs) = (id, panG, refs);

    }
}
