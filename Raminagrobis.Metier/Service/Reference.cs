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
        public static List<ReferenceMetier> GetAll()
        {
            var result = new List<ReferenceMetier>();
            var depot = new ReferenceDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new ReferenceMetier(item.ID, item.Reference,item.Nom,item.Marque));
            }
            return result;
        }
        public static ReferenceMetier GetByID(int id)
        {
            var depot = new ReferenceDepot_DAL();
            var reference = depot.GetByID(id);
            return new ReferenceMetier(reference.ID, reference.Reference, reference.Nom, reference.Marque);
        }

        public static void Insert(ReferenceTemp input)
        {
            var reference = new Reference_DAL(input.ReferenceO, input.Nom, input.Marque);
            var depot = new ReferenceDepot_DAL();
            input.ID = depot.Insert(reference).ID;
            
        }

        public static void Edit(int id, ReferenceTemp input)
        {
            var Reference = new Reference_DAL(id, input.ReferenceO, input.Nom, input.Marque);
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

        public static void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public static void MatchWithFournisseur(ReferenceTemp reference, int idFournisseur)
        {
            var depotAsso = new AssoRefFourDepot_DAL();
            var asso = new AssoRefFourn_DAL((int)reference.ID, idFournisseur);
            depotAsso.Insert(asso);
        }
    }
}
