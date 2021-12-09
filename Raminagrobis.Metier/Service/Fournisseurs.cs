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
        public static List<FournisseurMetier> GetAll()
        {
            var result = new List<FournisseurMetier>();
            var depot = new FournisseurDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new FournisseurMetier(item.ID,item.Nom,item.NomC,item.PrenomC,item.SexeC,item.Email,item.Adresse));    
            }
            return result;
        }
        public static FournisseurMetier GetByID(int id)
        {
            var depot = new FournisseurDepot_DAL();
            var item = depot.GetByID(id);
            return new FournisseurMetier(item.ID, item.Nom, item.NomC, item.PrenomC, item.SexeC, item.Email, item.Adresse);
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

    
