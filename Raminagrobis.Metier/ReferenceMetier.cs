using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.Metier
{
    
    public class ReferenceMetier
    {
        public string Refs { get; private set; }

        public string Nom { get; private set; }

        public string Marque { get; private set; }

        public ReferenceMetier(string refs, string nom, string marque)
        {
            Refs = refs;
            Nom= nom;
            Marque = marque;
        }
    }
}
