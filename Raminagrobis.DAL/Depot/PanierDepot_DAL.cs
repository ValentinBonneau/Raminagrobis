using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Raminagrobis.DAL.Depot
{
    public class PanierDepot_DAL : Depot_DAL<Panier_DAL>
    {
        public override List<Panier_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, idAdherent, idPanierG from Panier";
            var reader = commande.ExecuteReader();

            var listeDePanier = new List<Panier_DAL>();

            while (reader.Read())
            {
                var p = new Panier_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1)                         
                                         ); ;

                listeDePanier.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDePanier;

        }

        public override Panier_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, idAdherent, idPanierG from Panier where id=@id ";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();


            Panier_DAL reponse;

            if (reader.Read())
            {
                reponse = new Panier_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1)
                                        ); ;
            }
            else
            {
                throw new Exception($"Pas de fournisseur à l'id {ID}");
            }

            DetruireConnexionEtCommande();

            return reponse;
        }

        public override Panier_DAL Insert(Panier_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into Panier(idAdherent, idPanierG)" + " values (@idAdherent, @idPanierG); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@idAdherent", panier.IDAdherent));
            commande.Parameters.Add(new SqlParameter("@idPanierG", panier.IDPanierG));

            var id = Convert.ToInt32((decimal)commande.ExecuteScalar());

            panier.ID = id;
            var depotLigne = new LignePanierDepot_DAL();
            foreach (var item in panier.Lignes)
            {
                item.IDPanier = id;
                depotLigne.Insert(item);

            }


            DetruireConnexionEtCommande();

            return panier;
        }

        public override Panier_DAL Update(Panier_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Panier SET idAdherent = @idAdherent, idPanierG = @idPanierG where id = @id";
            commande.Parameters.Add(new SqlParameter("@idAdherent", item.IDAdherent));
            commande.Parameters.Add(new SqlParameter("@idPanierG", item.IDPanierG));

            commande.Parameters.Add(new SqlParameter("@id", item.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le panier d'ID {item.ID}");
            }


            DetruireConnexionEtCommande();

            return item;
        }

        public override void Delete(Panier_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from Panier where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", item.ID));
            var reader = commande.ExecuteReader();


            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"Aucune occurance à l'ID {item.ID} dans la table Panier");
            }
            DetruireConnexionEtCommande();
        }
    }
}
