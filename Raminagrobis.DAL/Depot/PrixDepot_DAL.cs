using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Raminagrobis.DAL.Depot
{
    public class PrixDepot_DAL : Depot_DAL<Prix_DAL>
    {
        public override List<Prix_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idLignePanierG, idFournisseur, prix from Prix";
            var reader = commande.ExecuteReader();

            var listeDeLigne = new List<Prix_DAL>();

            while (reader.Read())
            {
                var p = new Prix_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetDouble(2)
                                         );

                listeDeLigne.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDeLigne;

        }
        public List<Prix_DAL> GetByIDPanierG(int idPanierG)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select DISTINCT pr.idLignePanierG, pr.idFournisseur, pr.prix from Prix pr " +
                                    "Join LignePanierG lg On lg.id = pr.idLignePanierG " +
                                    "where lg.idPanierG = @idPanierG " +
                                    "ORDER BY pr.prix DESC";
            commande.Parameters.Add(new SqlParameter("@idPanierG", idPanierG));
            var reader = commande.ExecuteReader();

            var listeDeLigne = new List<Prix_DAL>();

            while (reader.Read())
            {
                var p = new Prix_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetDouble(2)
                                         );

                listeDeLigne.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDeLigne;
        }
        public override Prix_DAL GetByID(int idFournisseur)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idLignePanierG, idFournisseur, prix from Prix where idFournisseur=@idFournisseur";
            commande.Parameters.Add(new SqlParameter("@idFournisseur", idFournisseur));
            

            var reader = commande.ExecuteReader();


            Prix_DAL reponse;

            if (reader.Read())
            {
                reponse = new Prix_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetDouble(2)
                                        ); ;
            }
            else
            {
                throw new Exception($"Pas de Prix à l'id {idFournisseur}");
            }

            DetruireConnexionEtCommande();

            return reponse;
        }

        public override Prix_DAL Insert(Prix_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into Prix(idLignePanierG, idFournisseur, prix)" + " values (@idLignePanierG, @idFournisseur, @prix)";
            commande.Parameters.Add(new SqlParameter("@idLignePanierG", item.IDLignePanierG));
            commande.Parameters.Add(new SqlParameter("@idFournisseur", item.IDFournisseur));
            commande.Parameters.Add(new SqlParameter("@prix", item.Prix));
            commande.ExecuteNonQuery();

            


            DetruireConnexionEtCommande();

            return item;
        }

        public override Prix_DAL Update(Prix_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Prix SET prix = @prix where idLignePanierG = @idLignePanierG AND idFournisseur = @idFournisseur";
            commande.Parameters.Add(new SqlParameter("@idLignePanierG", item.IDLignePanierG));
            commande.Parameters.Add(new SqlParameter("@idFournisseur", item.IDFournisseur));
            commande.Parameters.Add(new SqlParameter("@prix", item.Prix));


            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {

                throw new Exception($"Impossible de mettre à jour le Prix d'ID {item.IDFournisseur}");

                throw new Exception($"Impossible de mettre à jour le Prix d'ID de panier global {item.IDLignePanierG} et l'ID de fournisseur {item.IDFournisseur}");

            }


            DetruireConnexionEtCommande();

            return item;
        }

        public override void Delete(Prix_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from Prix where idLignePanierG = @idLignePanierG AND idFournisseur = @idFournisseur";
            commande.Parameters.Add(new SqlParameter("@idFournisseur", item.IDFournisseur));
            commande.Parameters.Add(new SqlParameter("@idLignePanierG", item.IDLignePanierG));
            var reader = commande.ExecuteReader();


            if (commande.ExecuteNonQuery() == 0)
            {

                throw new Exception($"Aucune occurance à l'ID {item.IDFournisseur} dans la table Prix");

                throw new Exception($"Aucune occurance à  l'ID de panier global {item.IDLignePanierG} et l'ID de fournisseur {item.IDFournisseur} dans la table Prix");

            }
            DetruireConnexionEtCommande();
        }
    }
}

