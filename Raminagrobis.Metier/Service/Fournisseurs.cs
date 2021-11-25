using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;
using Raminagrobis.Metier;
using RaminagrobisDTO;

namespace Raminagrobis.Metier.Service
{
    public class Fournisseurs
    {
        public static List<FournisseurTemp> GetAll()
        {
            var result = new List<FournisseurTemp>();
            var depot = new FournisseurDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new FournisseurTemp() {
                    Nom = item.Nom,
                    NomC = item.NomC,
                    PrenomC = item.PrenomC,
                    Adresse = item.Adresse, 
                    Email = item.Email,
                    SexeC = item.SexeC 
                });    
            }
            return result;
        }
        public static FournisseurTemp GetByID(int id)
        {
            var depot = new FournisseurDepot_DAL();
            var fournisseur = depot.GetByID(id);
            return new FournisseurTemp()
            {
                Nom = fournisseur.Nom,
                NomC = fournisseur.NomC,
                PrenomC = fournisseur.PrenomC,
                Adresse = fournisseur.Adresse,
                Email = fournisseur.Email,
                SexeC = fournisseur.SexeC
            };
        }

        public static void Insert(FournisseurTemp input)
        {
            var fournisseur = new Fournisseur_DAL(input.Nom, input.PrenomC, input.NomC, input.SexeC, input.Email, input.Adresse);
            var depot = new FournisseurDepot_DAL();
            depot.Insert(fournisseur);
        }

        public static void Edit(int id, FournisseurTemp input)
        {
            var fournisseur = new Fournisseur_DAL(id,input.Nom, input.PrenomC, input.NomC, input.SexeC, input.Email, input.Adresse);
            var depot = new FournisseurDepot_DAL();
            depot.Update(fournisseur);
        }

        public static void Delete(int id)
        {
            Fournisseur_DAL fournisseur;
            FournisseurDepot_DAL depot = new FournisseurDepot_DAL();
            fournisseur = depot.GetByID(id);
            depot.Delete(fournisseur);
        }
        
    }
}

    
