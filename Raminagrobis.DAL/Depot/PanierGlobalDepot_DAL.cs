using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Raminagrobis.DAL.Depot
{
    public class PanierGlobalDepot_DAL : Depot_DAL<PanierGlobal_DAL>
    {
        public override List<PanierGlobal_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, date from PanierGlobal";
            var reader = commande.ExecuteReader();

            var listeDePanierG = new List<PanierGlobal_DAL>();

            while (reader.Read())
            {
                var p = new PanierGlobal_DAL(reader.GetInt32(0),
                                        reader.GetDateTime(1)
                                         ); 

                listeDePanierG.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDePanierG;

        }

        public override PanierGlobal_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, date from PanierGlobal where id=@id ";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();


            PanierGlobal_DAL reponse;

            if (reader.Read())
            {
                reponse = new PanierGlobal_DAL(reader.GetInt32(0),
                                        reader.GetDateTime(1)
                                        ); ;
            }
            else
            {
                throw new Exception($"Pas de PanierGlobal à l'id {ID}");
            }

            DetruireConnexionEtCommande();

            return reponse;
        }

        public override PanierGlobal_DAL Insert(PanierGlobal_DAL panierG)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into PanierGlobal(date)" + " values (@date); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@date", panierG.Date));
            var id = Convert.ToInt32((decimal)commande.ExecuteScalar());

            panierG.ID = id;
            var depotLigneG = new LignePanierGDepot_DAL();
            foreach (var item in panierG.LignesG)
            {
                item.IDPanierG = id;
                depotLigneG.Insert(item);

            }

            DetruireConnexionEtCommande();

            return panierG;
        }

        public override PanierGlobal_DAL Update(PanierGlobal_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update PanierGlobal SET date = @date where id = @id";
            commande.Parameters.Add(new SqlParameter("@date", item.Date));

            commande.Parameters.Add(new SqlParameter("@id", item.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le panierGlobal d'ID {item.ID}");
            }


            DetruireConnexionEtCommande();

            return item;
        }

        public override void Delete(PanierGlobal_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from PanierGlobal where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", item.ID));
            var reader = commande.ExecuteReader();


            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"Aucune occurance à l'ID {item.ID} dans la table PanierGlobal");
            }
            DetruireConnexionEtCommande();
        }
    }
}
