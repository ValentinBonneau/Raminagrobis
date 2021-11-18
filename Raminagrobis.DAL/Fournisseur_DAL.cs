using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Raminagrobis.DAL
{
    public class Fournisseur_DAL
    {
        public int ID { get; set; }
        public String Nom { get; private set; }
        public String PrenomC { get; private set; }
        public String NomC { get; private set; }
        public bool SexeC { get; private set; }
        public String Email { get; private set; }
        public String Adresse { get; private set; }
        

        public Fournisseur_DAL(int id, string nom, string prenomC, string nomC, bool sexeC, string email, string adresse)
            => (ID, Nom, PrenomC, NomC, SexeC, Email, Adresse) = (id, nom, prenomC, nomC, sexeC, email, adresse);
        public Fournisseur_DAL(string nom, string prenomC, string nomC, bool sexeC, string email, string adresse)
            => (Nom, PrenomC, NomC, SexeC, Email, Adresse) = (nom, prenomC, nomC, sexeC, email, adresse);



    }
}
