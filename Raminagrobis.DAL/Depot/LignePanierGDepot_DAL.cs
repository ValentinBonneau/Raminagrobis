using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Raminagrobis.DAL.Depot
{
    public class LignePanierGGDepot_DAL : Depot_DAL<LignePanierG_DAL>
    {
        public override List<LignePanierG_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, idPanierG, idRef from LignePanierG";
            var reader = commande.ExecuteReader();

            var listeDeLigne = new List<LignePanierG_DAL>();

            while (reader.Read())
            {
                var p = new LignePanierG_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2)
                                       
                                         );

                listeDeLigne.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDeLigne;

        }

        public override LignePanierG_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, idPanierG, idRef from LignePanierG where id=@id ";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();


            LignePanierG_DAL reponse;

            if (reader.Read())
            {
                reponse = new LignePanierG_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2)
                                        ); ;
            }
            else
            {
                throw new Exception($"Pas de LignePanierG à l'id {ID}");
            }

            DetruireConnexionEtCommande();

            return reponse;
        }

        public override LignePanierG_DAL Insert(LignePanierG_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into LignePanierG(idPanierG, idRef)" + " values (@idPanierG, @idRef); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@idRef", item.IDRef));
            commande.Parameters.Add(new SqlParameter("@idPanierG", item.IDPanierG));
            var id = Convert.ToInt32((decimal)commande.ExecuteScalar());

            item.ID = id;


            DetruireConnexionEtCommande();

            return item;
        }

        public override LignePanierG_DAL Update(LignePanierG_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update LignePanierG SET idLigneG=@idLigneG, idRef=@idRef where id = @id";
            commande.Parameters.Add(new SqlParameter("@idRef", item.IDRef));
            commande.Parameters.Add(new SqlParameter("@idPanierG", item.IDPanierG));

            commande.Parameters.Add(new SqlParameter("@id", item.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le LignePanierG d'ID {item.ID}");
            }


            DetruireConnexionEtCommande();

            return item;
        }

        public override void Delete(LignePanierG_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from LignePanierG where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", item.ID));
            var reader = commande.ExecuteReader();


            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"Aucune occurance à l'ID {item.ID} dans la table LignePanierG");
            }
            DetruireConnexionEtCommande();
        }
    }
}
}
