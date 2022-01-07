using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.Depot;
using Raminagrobis.DAL;
using RaminagrobisDTO;

namespace Raminagrobis.Metier.Service
{
    public class Prix
    {
        public static void Insert(List<PrixTemp> listePrix)
        {
            var depot = new PrixDepot_DAL();
            foreach (var item in listePrix)
            {
                depot.Insert(new Prix_DAL(item.IdLignePanierG,item.IdFournisseur, item.prix));
            }
        }
        public static List<PrixTemp> GetByPanierG(int idPanierG)
        {
            var depot = new PrixDepot_DAL();
            var lprix = new List<PrixTemp>();
            depot.GetByIDPanierG(idPanierG).ForEach(p => lprix.Add(new PrixTemp() {
                IdFournisseur = p.IDFournisseur,
                IdLignePanierG = p.IDLignePanierG,
                prix = p.Prix
            }));

            return lprix;

        }
    }
}
