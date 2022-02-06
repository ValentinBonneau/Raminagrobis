using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class AssoRefFourn_DAL
    {
        public int IDRef { get; private set; }
        public int IDFour { get; private set; }
        public Reference_DAL Ref { get; private set; }
        public Fournisseur_DAL Fours { get; private set; }

        public AssoRefFourn_DAL(Reference_DAL reference, Fournisseur_DAL four) => (Ref, Fours) = (reference, four);
        public AssoRefFourn_DAL(int idRef, int idFour) => (IDRef, IDFour) = (idRef, idFour);


    }
}
