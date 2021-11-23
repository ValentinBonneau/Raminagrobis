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
    public class Adherent
    {
        public static List<string> GetAll()
        {
            var result = new List<string>();
            var depot = new Adherent_Depot_DAL();
            foreach (var item in depot.GetAll())
            {
                var temp = JsonSerializer.Serialize(item);
                result.Add(temp);
            }
            return result;
        }
        public static string GetByID(int id)
        {
            var depot = new Adherent_Depot_DAL();
            var Adherent = depot.GetByID(id);
            return JsonSerializer.Serialize(Adherent);
        }

        public static void Insert(AdherentTemp input)
        {
            var Adherent = new Adherent_DAL(input.Nom, input.PrenomC, input.NomC, input.SexeC, input.Email, input.Adresse, input.DateA);
            var depot = new Adherent_Depot_DAL();
            depot.Insert(Adherent);
        }

        internal static void Edit(int id, AdherentTemp input)
        {
            var Adherent = new Adherent_DAL(id, input.Nom, input.PrenomC, input.NomC, input.SexeC, input.Email, input.Adresse, input.DateA);
            var depot = new Adherent_Depot_DAL();
            depot.Update(Adherent);
        }
        internal static void Delete(int id)
        {
            Adherent_DAL Adherent;
            Adherent_Depot_DAL depot = new Adherent_Depot_DAL();
            Adherent = depot.GetByID(id);
            depot.Delete(Adherent);

        }
        
    }
}
