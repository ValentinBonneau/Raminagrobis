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
        public int ID { get; private set; }
        public string Refs { get; private set; }

        public string Nom { get; private set; }

        public string Marque { get; private set; }

        public ReferenceMetier(string refs, string nom, string marque)
        {
            Refs = refs;
            Nom= nom;
            Marque = marque;
        }public ReferenceMetier(int id,string refs, string nom, string marque)
        {
            ID = id;
            Refs = refs;
            Nom= nom;
            Marque = marque;
        }
        public string getRef()
        {
            return Refs;
        }
        public string getNom()
        {
            return Nom;
        }
        public string getMarque()
        {
            return Marque;
        }
    }
}
