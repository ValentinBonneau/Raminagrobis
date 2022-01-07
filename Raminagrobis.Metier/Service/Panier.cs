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
        public static List<LignePanierMetier> Get(int idAherent, DateTime semaine)
        {
            var depotPanierG = new PanierGlobalDepot_DAL();
            var depotPanier = new PanierDepot_DAL();

            var result = new List<LignePanierMetier>();

            var panierG = depotPanierG.GetByDate(semaine); 
            var panier = depotPanier.GetbyIDAdherentNPanierG(idAherent,panierG.ID);
            var prix = Prix.GetByPanierG(panierG.ID);

            foreach (var item in panier.Lignes)
            {
                var laligne = panierG.LignesG.Where(ligne_ => ligne_.IDRef == item.IdRef).First();
                var leprix = prix.Where(prix_ => prix_.IdLignePanierG == laligne.ID).First().prix;
                result.Add(new LignePanierMetier(item.IdRef,item.Quantite,leprix,item.IDPanier));
            }

            return result;

        }
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
