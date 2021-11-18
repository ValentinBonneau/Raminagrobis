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

        public static void Insert(string json)
        {
            var fournisseur = JsonSerializer.Deserialize<Fournisseur_DAL>(json);
            var depot = new FournisseurDepot_DAL();
            depot.Insert(fournisseur);
        }
        public static void Insert(string nom, string prenomC, string nomC, bool sexeC, string email, string adresse)
        {
            var fournisseur = new Fournisseur_DAL(nom, prenomC, nomC, sexeC, email, adresse);
            var depot = new FournisseurDepot_DAL();
            depot.Insert(fournisseur);
        }
    }
}

    
