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
        public static List<AdherentMetier> GetAll()
        {
            var result = new List<AdherentMetier>();
            var depot = new Adherent_Depot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new AdherentMetier(item.ID,item.Nom,item.NomC,item.PrenomC,item.SexeC,item.Email,item.Adresse,item.DateA));
            }
            return result;
        }
        public static AdherentMetier GetByID(int id)
        {
            var depot = new Adherent_Depot_DAL();
            var adherent = depot.GetByID(id);
            return new AdherentMetier(adherent.ID, adherent.Nom, adherent.NomC, adherent.PrenomC, adherent.SexeC, adherent.Email, adherent.Adresse, adherent.DateA);
        }

        public static void Insert(AdherentTemp input)
        {
            var Adherent = new Adherent_DAL(input.Nom, input.PrenomC, input.NomC, input.SexeC, input.Email, input.Adresse, input.DateA.ToLocalTime().DateTime);
            var depot = new Adherent_Depot_DAL();
            depot.Insert(Adherent);
        }

        public static void Edit(int id, AdherentTemp input)
        {
            var Adherent = new Adherent_DAL(id, input.Nom, input.PrenomC, input.NomC, input.SexeC, input.Email, input.Adresse, input.DateA.ToLocalTime().DateTime);
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
