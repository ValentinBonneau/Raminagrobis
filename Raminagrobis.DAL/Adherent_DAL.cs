using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Adherent_DAL
    {
        public int ID { get; private set; }
        public String Nom { get; private set; }
        public String PrenomC { get; private set; }
        public String NomC { get; private set; }
        public String SexeC { get; private set; }
        public String Email { get; private set; }
        public String Adresse { get; private set; }
        public DateTime DateA { get; private set; }

        

        public Adherent_DAL(int id, string nom, string prenomC, string nomC, string sexeC, string email, string adresse, DateTime date)
            => (ID, Nom, PrenomC, NomC, SexeC, Email, Adresse, DateA) = (id, nom, prenomC, nomC, sexeC, email, adresse, date);

    }
}
