using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;
using Raminagrobis.Metier;
using System.Text.Json;
using System.Text.Json.Serialization;
using RaminagrobisAPI.Tampon;

namespace RaminagrobisAPI.Models
{
    public class Fournisseurs
    {
        public static List<string> GetAll()
        {
            var result = new List<string>();
            var depot = new FournisseurDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                var temp = JsonSerializer.Serialize(item);
                result.Add(temp);
            }
            return result;
        }
        public static string GetByID(int id)
        {
            var depot = new FournisseurDepot_DAL();
            var fournisseur = depot.GetByID(id);
            return JsonSerializer.Serialize(fournisseur);
        }

        public static void Insert(FournisseurTemp input)
        {
            var fournisseur = new Fournisseur_DAL(input.Nom, input.PrenomC, input.NomC, input.SexeC, input.Email, input.Adresse);
            var depot = new FournisseurDepot_DAL();
            depot.Insert(fournisseur);
        }
    }
}

    
