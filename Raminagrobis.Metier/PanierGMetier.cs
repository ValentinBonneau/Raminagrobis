using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.Metier
{
    class PanierGMetier
    {
        public int ID { get; private set; }
        public DateTime Date { get; private set; }
        public List<LignePanierG_DAL> lignesG { get; private set; }

        public PanierGMetier(int id,  DateTime date, List<LignePanierGMetier> ligneG)
        {
            ID = id;
            Date = date;
            lignesG = lignesG;
        }
       
        public void Insert()
        {
            PanierGlobal_DAL panierG = new PanierGlobal_DAL(ID, Date);
            PanierGlobalDepot_DAL panierGD = new PanierGlobalDepot_DAL();
            panierGD.Insert(panierG);
        }
    }
}
