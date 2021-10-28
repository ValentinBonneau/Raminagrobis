using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Raminagrobis.DAL
{
    public class Fournisseur_DAL
    {
        public int ID { get; private set; }
        public string nom { get; private set; }
        public string prenomC { get; private set; }
        public string nomC { get; private set; }
        public string sexeC { get; private set; }
        public string email { get; private set; }
        public string adresse { get; private set; }



    }
}
