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
using RaminagrobisDTO;

namespace Raminagrobis.Metier.Service
{
    public class Reference
    {
        public static List<ReferenceTemp> GetAll()
        {
            var result = new List<ReferenceTemp>();
            var depot = new ReferenceDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new ReferenceTemp()
                {
                    Marque = item.Marque,
                    Nom = item.Nom,
                    Reference = item.Reference
                }) ;
            }
            return result;
        }
        public static ReferenceTemp GetByID(int id)
        {
            var depot = new ReferenceDepot_DAL();
            var reference = depot.GetByID(id);
            return new ReferenceTemp()
            {
                Marque = reference.Marque,
                Nom = reference.Nom,
                Reference = reference.Reference
            };
        }

        public static void Insert(ReferenceTemp input)
        {
            var Reference = new Reference_DAL(input.Reference, input.Nom, input.Marque);
            var depot = new ReferenceDepot_DAL();
            depot.Insert(Reference);
        }

        public static void Edit(int id, ReferenceTemp input)
        {
            var Reference = new Reference_DAL(id, input.Reference, input.Nom, input.Marque);
            var depot = new ReferenceDepot_DAL();
            depot.Update(Reference);
        }

        public static void Delete(int id)
        {
            Reference_DAL Reference;
            ReferenceDepot_DAL depot = new ReferenceDepot_DAL();
            Reference = depot.GetByID(id);
            depot.Delete(Reference);
        }
    }
}
