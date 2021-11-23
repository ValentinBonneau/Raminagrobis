﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.Metier
{
    class LignePanierGMetier
    {
       public int IDPanierG { get; private set; }
       public int IDRef { get; private set; }

       public LignePanierGMetier(int idPanierG, int idRef)
        {
            IDPanierG = idPanierG;
            IDRef = idRef;
        }
    }
}
