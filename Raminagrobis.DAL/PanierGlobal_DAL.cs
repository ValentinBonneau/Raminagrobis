using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class PanierGlobal_DAL
    {
        public int ID { get; set; }
        public DateTime Date { get; private set; }
        public List<LignePanierG_DAL> LignesG { get; private set; }
        public PanierGlobal_DAL(IEnumerable<LignePanierG_DAL> desLignesG) => (LignesG) = (desLignesG.ToList());
        public PanierGlobal_DAL(int id, DateTime date, IEnumerable<LignePanierG_DAL> desLignesG)
            => (ID, Date, LignesG) = (id, date, desLignesG.ToList());
        public PanierGlobal_DAL(int id, DateTime date) => (ID, Date) = (id, date);

    }
}
    