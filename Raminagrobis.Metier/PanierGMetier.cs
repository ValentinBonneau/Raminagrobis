using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.Metier
{
    class PanierGMetier
    {
        public DateTime Date { get; private set; }
        
        public PanierGMetier(DateTime date)
        {
            Date = date;
        }
    }
}
