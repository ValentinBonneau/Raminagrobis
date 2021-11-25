using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Raminagrobis.DAL.Depot
{
    public class AssoRefFourDepot_DAL : Depot_DAL<AssoRefFourn_DAL>
    {
        public override List<AssoRefFourn_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, idRef, quantite, idPanier from LignePanier";
            var reader = commande.ExecuteReader();

            var listeDeLigne = new List<AssoRefFourn_DAL>();

            while (reader.Read())
            {
                var p = new AssoRefFourn_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1)
                                         );

                listeDeLigne.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDeLigne;

        }

        public override AssoRefFourn_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select idRef, idFournisseur from LignePanier where id=@id ";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();


            AssoRefFourn_DAL reponse;

            if (reader.Read())
            {
                reponse = new AssoRefFourn_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1)
                                        ); ;
            }
            else
            {
                throw new Exception($"Pas de LignePanier à l'id {ID}");
            }

            DetruireConnexionEtCommande();

            return reponse;
        }

        public override AssoRefFourn_DAL Insert(AssoRefFourn_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into AssoRefFournisseur(idRef, idFournisseur)" + " values (@idRef, @idFournisseur); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@idRef", item.IDRef));
            commande.Parameters.Add(new SqlParameter("@idFournisseur", item.IDFour));
            commande.ExecuteNonQuery();

            DetruireConnexionEtCommande();

            return item;
        }

        public override AssoRefFourn_DAL Update(AssoRefFourn_DAL item)
        {
            CreerConnexionEtCommande();



            DetruireConnexionEtCommande();

            return item;
        }

        public override void Delete(AssoRefFourn_DAL item)
        {
            CreerConnexionEtCommande();

            DetruireConnexionEtCommande();
        }
    }
}
