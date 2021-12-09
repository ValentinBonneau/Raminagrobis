using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.Metier
{
    public class PanierGMetier
    {
        public int ID { get; private set; }
        public DateTime Date { get; private set; }
        public List<LignePanierGMetier> LignesG { get; private set; }

        public PanierGMetier(int id,  DateTime date, List<LignePanierGMetier> ligneG)
        {
            ID = id;
            Date = date;
            LignesG = ligneG;
        }
    }
}
