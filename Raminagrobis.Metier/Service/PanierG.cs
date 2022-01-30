using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.Metier.Service
{
    public class PanierG
    {
        public static PanierGMetier GetByDate(DateTime semaine)
        {

            var depotPannierG = new PanierGlobalDepot_DAL();
            var depotLigneG = new LignePanierGDepot_DAL();
            var depotRef = new ReferenceDepot_DAL();

            var panier = depotPannierG.GetByDate(semaine);
            Update(panier.ID);
            var lignes = new List<LignePanierGMetier>();

            foreach (var ligne in depotLigneG.GetByIDPanierG(panier.ID))
            {

                lignes.Add(new LignePanierGMetier(ligne.ID, panier.ID, ligne.Quantite, depotRef.GetByID(ligne.IDRef).Reference));
            }

            return new PanierGMetier(panier.ID, panier.Date, lignes);
        }
        public static List<LignePanierGMetier> GetLigneByFournisseur(int IDfournisseur, DateTime semaine)
        {
            Update();
            var depotLignePannier = new LignePanierGDepot_DAL();
            var list = depotLignePannier.GetByIDFournisseur(IDfournisseur, semaine);

            var result = new List<LignePanierGMetier>();
            foreach (var item in list)
            {
                result.Add(new LignePanierGMetier(item.ID, item.IDPanierG, item.Quantite, item.IDRef));
            }
            return result;
        }
        /// <summary>
        /// Update le dernier panier
        /// </summary>
        public static void Update()
        {
            var depotPannierG = new PanierGlobalDepot_DAL();
            var panier = depotPannierG.GetByDate(DateTime.Now);
            Update(panier.ID);
        }
        /// <summary>
        /// Update le panier avec l'id spécifié
        /// </summary>
        /// <param name="id">l'id spécifié</param>
        public static void Update(int id)
        {
            var depotPannier = new PanierDepot_DAL();
            var depotLignePannier = new LignePanierDepot_DAL();

            var LignePanierGlobal = new Dictionary<int, int>();

            foreach (var panier in depotPannier.GetByIDPanierG(id))
            {
                foreach (var ligne in depotLignePannier.GetBYIDPanier(panier.ID))
                {
                    if (LignePanierGlobal.Count(l => l.Key == ligne.IdRef) > 0)
                    {
                        LignePanierGlobal[ligne.IdRef] += ligne.Quantite;
                    }
                    else
                    {
                        LignePanierGlobal.Add(ligne.IdRef, ligne.Quantite);
                    }
                }
            }

            var depotLigneGlobal = new LignePanierGDepot_DAL();



            foreach (var ligne in LignePanierGlobal)
            {
                var ligneDal = new LignePanierG_DAL(id, ligne.Key, ligne.Value);
                if (depotLigneGlobal.Exist(ligneDal))
                {
                    ligneDal.ID = depotLigneGlobal.GetByIDPanierG(ligneDal.IDPanierG).Where(l => l.IDRef == ligneDal.IDRef).First().ID;
                    depotLigneGlobal.Update(ligneDal);
                }
                else
                {
                    depotLigneGlobal.Insert(ligneDal);
                }
            }
        }
    }
}
