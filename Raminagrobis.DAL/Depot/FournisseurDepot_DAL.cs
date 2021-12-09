using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Raminagrobis.DAL.Depot
{
    public class FournisseurDepot_DAL : Depot_DAL<Fournisseur_DAL>
    {

        public override List<Fournisseur_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, prenomC, nomC, sexeC, email, adresse from Fournisseur ";
            var reader = commande.ExecuteReader();

            var listeDeFournisseur = new List<Fournisseur_DAL>();
               

            while (reader.Read())
            {
                var p = new Fournisseur_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetString(6)
                                        ); ;

                listeDeFournisseur.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDeFournisseur;

        }
        public override Fournisseur_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, prenomC, nomC, sexeC, email, adresse from Fournisseur where id=@id ";
            commande.Parameters.Add(new SqlParameter("@id", ID.ToString()));
            var reader = commande.ExecuteReader();


            Fournisseur_DAL reponse ;

            if (reader.Read())
            {
                reponse = new Fournisseur_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetString(6)
                                        );
            }
            else
            {
                throw new Exception($"Pas de fournisseur à l'id {ID}");
            }

            DetruireConnexionEtCommande();

            return reponse;

        }
        public List<Fournisseur_DAL> GetAllByIDRef(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, prenomc, nomC, sexeC, email, adresse from Fournisseur where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));

            var reader = commande.ExecuteReader();

            var listeDeFournisseur = new List<Fournisseur_DAL>();

            while (reader.Read())
            {
                var p = new Fournisseur_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetString(6));

                listeDeFournisseur.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDeFournisseur;
        }
        public override Fournisseur_DAL Insert(Fournisseur_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into Fournisseur(nom, prenomC, nomC, sexeC, email, adresse)" + " values (@nom, @prenomC, @nomC, @sexeC, @email, @adresse); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@nom", item.Nom));
            commande.Parameters.Add(new SqlParameter("@prenomC", item.PrenomC));
            commande.Parameters.Add(new SqlParameter("@nomC", item.NomC));
            commande.Parameters.Add(new SqlParameter("@sexeC", item.SexeC.ToString()));
            commande.Parameters.Add(new SqlParameter("@email", item.Email));
            commande.Parameters.Add(new SqlParameter("@adresse", item.Adresse));
            var id = Convert.ToInt32((decimal)commande.ExecuteScalar());

            item.ID = id;


            DetruireConnexionEtCommande();

            return item;
        }

        public override Fournisseur_DAL Update(Fournisseur_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Fournisseur SET nom = @nom, prenomC = @prenomC, nomC = @nomC, sexeC = @sexeC, email = @email, adresse = @adresse where id = @id";
            commande.Parameters.Add(new SqlParameter("@nom", item.Nom));
            commande.Parameters.Add(new SqlParameter("@prenomC", item.PrenomC));
            commande.Parameters.Add(new SqlParameter("@nomC", item.NomC));
            commande.Parameters.Add(new SqlParameter("@sexeC", item.SexeC));
            commande.Parameters.Add(new SqlParameter("@email", item.Email));
            commande.Parameters.Add(new SqlParameter("@adresse", item.Adresse));
            commande.Parameters.Add(new SqlParameter("@id", item.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le fournisseur d'ID {item.ID}");
            }


            DetruireConnexionEtCommande();

            return item;
        }

        public override void Delete(Fournisseur_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from Fournisseur where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", item.ID));

            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"Aucune occurance à l'ID {item.ID} dans la table Fournisseur");
            }
            DetruireConnexionEtCommande();
        }

    }
}
