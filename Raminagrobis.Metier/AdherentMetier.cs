using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Metier
{
    class AdherentMetier
    {
        public string Nom { get; private set; }
        public string NomC { get; private set; }
        public string PrenomC { get; private set; }
        public string SexeC { get; private set; }
        public string Email { get; private set; }
        public string Adresse { get; private set; }

        
        public AdherentMetier(string nom, string nomC, string prenomC, string sexeC, string email, string adresse)
        {
            Nom = nom;
            NomC = nomC;
            PrenomC = prenomC;
            SexeC = sexeC;
            Email = email;
            Adresse = adresse;
            
        }
    }
}
