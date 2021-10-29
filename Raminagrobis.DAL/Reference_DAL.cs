using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Reference_DAL
    {

        public int ID { get; set; }
        public String Reference { get; private set; }
        public String Nom { get; private set; }
        public String Marque { get; private set; }
        public List<Fournisseur_DAL> Fours { get; private set; }

        public Reference_DAL(IEnumerable<Fournisseur_DAL> desFours) => (Fours) = (desFours.ToList());

        public Reference_DAL(int id, string reference, string nom, string marque, IEnumerable<Fournisseur_DAL> desFours)
            => (ID, Reference, Nom, Marque, Fours) = (id, reference, nom, marque, desFours.ToList());

        

    }
}
