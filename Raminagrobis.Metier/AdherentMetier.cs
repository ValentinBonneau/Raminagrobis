using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.Metier
{
    class AdherentMetier
    {
        public int ID { get; private set; }
        public string Nom { get; private set; }
        public string NomC { get; private set; }
        public string PrenomC { get; private set; }
        public string SexeC { get; private set; }
        public string Email { get; private set; }
        public string Adresse { get; private set; }
        public DateTime Date { get; private set; }
        public PanierMetier paniers { get; private set; }


        
        public AdherentMetier(int id, string nom, string nomC, string prenomC, string sexeC, string email, string adresse)

        {
            ID = id;
            Nom = nom;
            NomC = nomC;
            PrenomC = prenomC;
            SexeC = sexeC;
            Email = email;
            Adresse = adresse;

        }

        public void Insert()
        {
            Adherent_DAL adherent = new Adherent_DAL(Nom, NomC, PrenomC, SexeC, Email, Adresse, Date);
            Adherent_Depot_DAL adh = new Adherent_Depot_DAL();
            adh.Insert(adherent);
        }

    }
    
}
