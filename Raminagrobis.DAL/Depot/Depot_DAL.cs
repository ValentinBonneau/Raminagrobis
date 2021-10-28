using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace Raminagrobis.DAL.Depot
{
    abstract public class Depot_DAL<Type_DAL> : IDepot<Type_DAL>
    {
        public string ChaineDeConnexion { get; set; }

        protected SqlConnection connexion;
        protected SqlCommand command;

        public Depot_DAL()
        {
            var builder = new ConfigurationBuilder();
            var config = builder.AddJsonFile("appsettings.json", false, true).Build();
            ChaineDeConnexion = config.GetSection("ConnectionStrings:default").Value;
        }

        protected void CreerConnexionEtCommande()
        {
            connexion = new SqlConnection(ChaineDeConnexion);
            connexion.Open();
            command = new SqlCommand();
            command.Connection = connexion;
        }

        protected void DetruireConnexionEtCommande()
        {
            command.Dispose();
            connexion.Close();
            connexion.Dispose();

        }
        #region Méthodes Abstraite
        public abstract List<Type_DAL> GetAll();

        public abstract Type_DAL GetByID(int ID);

        public abstract Type_DAL Insert(Type_DAL item);

        public abstract Type_DAL Update(Type_DAL item);

        public abstract void Delete(Type_DAL item);
        #endregion
    }
}
