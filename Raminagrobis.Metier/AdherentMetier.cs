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

        public void ajouterPanier( int idPanierG, List<LignePanierMetier> ligne)
        {
            paniers = new PanierMetier(ID , idPanierG, ligne);

        }


        public void ajouterLignePanierFromCSV(StreamReader sr)
        {
            var line = sr.ReadLine();
            var columnName = line.Split(";");

            if (columnName.Length == 3)
            {
                while (!sr.EndOfStream)
                {
                    var column = sr.ReadLine().Split(";");
                    string refs = ""; 
                    int quantite = 0;

                    for (int i = 0; i < 2; i++)
                    {
                        switch (columnName[i])
                        {
                            case "reference":
                                refs = column[i];
                                break;
                            case "quantite":
                                quantite = int.Parse(column[i]);
                                break;
                            
                            default:
                                throw new Exception($"Syntaxe incorecte dans le nom de la colone : {columnName[i]} ");
                        }
                    }
                    if (refs == "" || quantite == null)
                    {
                        throw new Exception($"l'une des ligne du Csv ne contien pas d'information");
                    }
                    else
                    {
                        paniers.ajouterLigne(refs, quantite, ID);

                    }
                }
            }
            else
            {
                throw new Exception("Le Csv fournit pour les references d'un fournisseur n'est pas au bon format ");
            }

        }

        public List<LignePanierMetier> getLignePanier()
        {
            return paniers.getLigne();
        }

    }
    
}
