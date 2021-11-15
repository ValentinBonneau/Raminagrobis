using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Metier
{
    class PanierGMetier
    {
        public int ID { get; private set; }
        public DateTime Date { get; private set; }
        List<LignePanierGMetier> lignesG;

        public PanierGMetier(int id,  DateTime date, List<LignePanierGMetier> ligneG)
        {
            ID = id;
            Date = date;
            lignesG = ligneG;
        }
        public PanierGMetier(List<PanierMetier> paniers)
        {
            foreach 
            (var panier in paniers)
            {
               
                foreach (var item in panier.lignes)
                {
                    try
                    {
                        getLigneByRef(item.refs).Quantite += item.Quantite;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    ajouterLigneG(item.Quantite, item.refs);
                }
            }
        }

        public void ajouterLigneG(int quantite, string refs)
        {
            LignePanierGMetier ligneG = new LignePanierGMetier(ID, quantite, refs );
            lignesG.Add(ligneG);
        }
        public LignePanierGMetier getLigneByRef(string reference)
        {
            var ligne = lignesG.Where(ligne => ligne.refs == reference);
            return ligne.First();
        }
    }
}
