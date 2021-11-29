using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;
using RaminagrobisDTO;

namespace Raminagrobis.Metier.Service
{
    public class Panier
    {
        public static void Insert(PanierTemp input, int idAdherent)
        {
            
            var depot = new PanierDepot_DAL();

            var lignes = new List<LignePanier_DAL>();
            foreach (var item in input.Lignes)
            {
                lignes.Add(new LignePanier_DAL(item.Ref, item.Quantite));
            }
            var panier = new Panier_DAL(idAdherent,0,lignes);
            depot.Insert(panier);
        }
    }
}
