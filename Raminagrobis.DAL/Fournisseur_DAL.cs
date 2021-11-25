using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Raminagrobis.DAL
{
    public class Fournisseur_DAL
    {
        public int ID { get; set; }
        public String Nom { get; set; }
        public String PrenomC { get; set; }
        public String NomC { get; set; }
        public String SexeC { get; set; }
        public String Email { get; set; }
        public String Adresse { get; set; }
        

        public Fournisseur_DAL(int id, string nom, string prenomC, string nomC, string sexeC, string email, string adresse)
            => (ID, Nom, PrenomC, NomC, SexeC, Email, Adresse) = (id, nom, prenomC, nomC, sexeC, email, adresse);
        public Fournisseur_DAL(string nom, string prenomC, string nomC, string sexeC, string email, string adresse)
            => (Nom, PrenomC, NomC, SexeC, Email, Adresse) = (nom, prenomC, nomC, sexeC, email, adresse);



    }
}
