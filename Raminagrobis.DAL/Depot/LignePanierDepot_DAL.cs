using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Raminagrobis.DAL.Depot
{
    public class LignePanierDepot_DAL : Depot_DAL<LignePanier_DAL>
    {
        public override List<LignePanier_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, idRef, quantite, idPanier from LignePanier";
            var reader = commande.ExecuteReader();

            var listeDeLigne = new List<LignePanier_DAL>();

            while (reader.Read())
            {
                var p = new LignePanier_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3)
                                         );

                listeDeLigne.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDeLigne;

        }

        public override LignePanier_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, idRef, quantite, idPanier from LignePanier where id=@id ";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();


            LignePanier_DAL reponse;

            if (reader.Read())
            {
                reponse = new LignePanier_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3)
                                        ); ;
            }
            else
            {
                throw new Exception($"Pas de LignePanier à l'id {ID}");
            }

            DetruireConnexionEtCommande();

            return reponse;
        }

        public override LignePanier_DAL Insert(LignePanier_DAL item)
        {
            var refDepot = new ReferenceDepot_DAL();
            var idRef = refDepot.GetByRef(item.Ref).ID;
            CreerConnexionEtCommande();

            commande.CommandText = "insert into LignePanier(idRef, quantite, idPanier)" + " values (@idRef, @quantite, @idPanier); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@idRef", idRef));
            commande.Parameters.Add(new SqlParameter("@quantite", item.Quantite));
            commande.Parameters.Add(new SqlParameter("@idPanier", item.IDPanier));
            item.ID = Convert.ToInt32((decimal)commande.ExecuteScalar());


            DetruireConnexionEtCommande();

            return item;
        }

        public override LignePanier_DAL Update(LignePanier_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update LignePanier SET idRef=@idRef, quantite = @quantite, idPanier = @idPanier where id = @id";
            commande.Parameters.Add(new SqlParameter("@idRef", item.Ref));
            commande.Parameters.Add(new SqlParameter("@quantite", item.Quantite));
            commande.Parameters.Add(new SqlParameter("@idPanier", item.IDPanier));

            commande.Parameters.Add(new SqlParameter("@id", item.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le LignePanier d'ID {item.ID}");
            }


            DetruireConnexionEtCommande();

            return item;
        }

        public override void Delete(LignePanier_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from LignePanier where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", item.ID));
            var reader = commande.ExecuteReader();


            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"Aucune occurance à l'ID {item.ID} dans la table LignePanier");
            }
            DetruireConnexionEtCommande();
        }
    }

}

