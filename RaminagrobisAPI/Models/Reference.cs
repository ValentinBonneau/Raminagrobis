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
    public class Reference
    {
        public static List<string> GetAll()
        {
            var result = new List<string>();
            var depot = new ReferenceDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                var temp = JsonSerializer.Serialize(item);
                result.Add(temp);
            }
            return result;
        }
        public static string GetByID(int id)
        {
            var depot = new ReferenceDepot_DAL();
            var Reference = depot.GetByID(id);
            return JsonSerializer.Serialize(Reference);
        }

        public static void Insert(ReferenceTemp input)
        {
            var Reference = new Reference_DAL(input.Reference, input.Nom, input.Marque);
            var depot = new ReferenceDepot_DAL();
            depot.Insert(Reference);
        }

        internal static void Edit(int id, ReferenceTemp input)
        {
            var Reference = new Reference_DAL(id, input.Reference, input.Nom, input.Marque);
            var depot = new ReferenceDepot_DAL();
            depot.Update(Reference);
        }

        internal static void Delete(int id)
        {
            Reference_DAL Reference;
            ReferenceDepot_DAL depot = new ReferenceDepot_DAL();
            Reference = depot.GetByID(id);
            depot.Delete(Reference);
        }
    }
}
