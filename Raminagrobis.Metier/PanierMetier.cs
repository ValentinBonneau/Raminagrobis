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


        public PanierMetier(int idAdherent, int idPanierG)
        {
            IDAdherent = idAdherent;
            IDPanierG = idPanierG;
        } 
    }
}
