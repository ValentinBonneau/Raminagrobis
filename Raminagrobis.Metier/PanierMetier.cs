using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.Metier
{
    class PanierMetier
    {
        public int ID { get; private set; }
        public int IDAdherent { get; private set; }
        public int IDPanierG { get; private set; }
        public List<LignePanier_DAL> desLignes { get; private set; }

        public List<LignePanierMetier> lignes { get; private set; }




        public PanierMetier(int id, int idAdherent, int idPanierG, List<LignePanierMetier> ligne)

        {
            ID = id;
            IDAdherent = idAdherent;
            IDPanierG = idPanierG;
            lignes = ligne;
        }

        public void AddFromCSV(StreamReader sr)
        {

            var line = sr.ReadLine();
            var columnName = line.Split(";");

            if (columnName.Length == 2)
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
                                quantite = Int32.Parse(column[i]);
                                break;

                            default:
                                throw new Exception($"Syntaxe incorecte dans le nom de la colone : {columnName[i]} ");
                        }
                    }
                    if (refs == "" || quantite == 0)
                    {
                        throw new Exception($"l'une des ligne du Csv ne contien pas d'information");
                    }
                    else
                    {

                        this.Ajouter_Ligne(new LignePanier_DAL(refs, quantite, ID));

                    }
                }
            }
            else
            {
                throw new Exception("Le Csv fournit pour les references d'un fournisseur n'est pas au bon format ");
            }


            PanierDepot_DAL panierD = new PanierDepot_DAL();
            Panier_DAL panier = new Panier_DAL(IDAdherent, IDPanierG, desLignes);
            panierD.Insert(panier);
        }
        public void Ajouter_Ligne(LignePanier_DAL ligne)
        {
            desLignes.Add(ligne);
        }
    }
}
