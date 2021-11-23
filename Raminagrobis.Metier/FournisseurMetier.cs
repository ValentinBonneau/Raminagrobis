using System;
using System.Collections.Generic;
using System.IO;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.Metier
{
    public class FournisseurMetier
    {
        public string Nom { get; private set; }
        public string NomC { get; private set; }
        public string PrenomC { get; private set; }
        public string SexeC { get; private set; }
        public string Email { get; private set; }
        public string Adresse { get; private set; }

        public List<ReferenceMetier> Refs { get; private set; }
        public FournisseurMetier(string nom, string nomC, string prenomC, string sexeC, string email, string adresse)
        {
            Nom = nom;
            NomC = nomC;
            PrenomC = prenomC;
            SexeC = sexeC;
            Email = email;
            Adresse = adresse;
            Refs = new List<ReferenceMetier>();
        }

        public void Ajouter_References(List<ReferenceMetier> refs) {
            foreach (var item in refs)
            {
                Refs.Add(item);
            }
        }

        public void Ajouter_References_From_CSV(StreamReader sr)
        {
            var line = sr.ReadLine();
            var columnName = line.Split(";");

            if (columnName.Length == 3)
            {
                while (!sr.EndOfStream)
                {
                    var column = sr.ReadLine().Split(";");
                    string refs = "", nom = "", marque = "";

                    for (int i = 0; i < 3; i++)
                    {
                        switch (columnName[i])
                        {
                            case "reference":
                                refs = column[i];
                                break;
                            case "libelle":
                                nom = column[i];
                                break;
                            case "marque":
                                marque = column[i];
                                break;
                            default:
                                throw new Exception($"Syntaxe incorecte dans le nom de la colone : {columnName[i]} ");
                        }
                    }
                    if (refs == "" || nom == "" || marque == "")
                    {
                        throw new Exception($"l'une des ligne du Csv ne contien pas d'information");
                    }
                    else
                    {
                        this.Ajouter_Reference(new ReferenceMetier(refs, nom, marque));

                    }
                }
            }
            else
            {
                throw new Exception("Le Csv fournit pour les references d'un fournisseur n'est pas au bon format ");
            }
            
        }

        public void Ajouter_Reference(ReferenceMetier refs)
        {
                Refs.Add(refs);
        }


        


    }
}
