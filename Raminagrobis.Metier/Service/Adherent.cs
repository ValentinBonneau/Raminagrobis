using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;
using Raminagrobis.Metier;
using System.Text.Json;
using System.Text.Json.Serialization;
using RaminagrobisDTO;

namespace Raminagrobis.Metier.Service
{
    public class Adherent
    {
        public static List<AdherentTemp> GetAll()
        {
            var result = new List<AdherentTemp>();
            var depot = new Adherent_Depot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new AdherentTemp()
                {
                    Nom = item.Nom,
                    NomC = item.NomC,
                    PrenomC = item.PrenomC,
                    SexeC = item.SexeC,
                    Adresse = item.Adresse,
                    DateA = item.DateA,
                    Email = item.Email
                });
            }
            return result;
        }
        public static AdherentTemp GetByID(int id)
        {
            var depot = new Adherent_Depot_DAL();
            var adherent = depot.GetByID(id);
            return new AdherentTemp()
                {
                    Nom = adherent.Nom,
                    NomC = adherent.NomC,
                    PrenomC = adherent.PrenomC,
                    SexeC = adherent.SexeC,
                    Adresse = adherent.Adresse,
                    DateA = adherent.DateA,
                    Email = adherent.Email
                };
        }

        public static void Insert(AdherentTemp input)
        {
            var Adherent = new Adherent_DAL(input.Nom, input.PrenomC, input.NomC, input.SexeC, input.Email, input.Adresse, input.DateA);
            var depot = new Adherent_Depot_DAL();
            depot.Insert(Adherent);
        }

        public static void Edit(int id, AdherentTemp input)
        {
            var Adherent = new Adherent_DAL(id, input.Nom, input.PrenomC, input.NomC, input.SexeC, input.Email, input.Adresse, input.DateA);
            var depot = new Adherent_Depot_DAL();
            depot.Update(Adherent);
        }
        public static void Delete(int id)
        {
            Adherent_DAL Adherent;
            Adherent_Depot_DAL depot = new Adherent_Depot_DAL();
            Adherent = depot.GetByID(id);
            depot.Delete(Adherent);

        }
        
    }
}
