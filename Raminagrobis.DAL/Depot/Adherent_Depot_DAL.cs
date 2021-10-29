using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL.Depot
{
    class Adherent_Depot_DAL : Depot_DAL<Adherent_DAL>
    {
        

        public override List<Adherent_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id,nom,prenomC,nomC,sexeC,email,adresse,dateA FROM Adherent";
            var reader = commande.ExecuteReader();

            var reponse = new List<Adherent_DAL>();

            while (reader.Read())
            {
                var adherent = new Adherent_DAL(
                    reader.GetInt32(0),
                    reader.GetString(1), 
                    reader.GetString(2), 
                    reader.GetString(3), 
                    reader.GetString(4), 
                    reader.GetString(5), 
                    reader.GetString(6),
                    reader.GetDateTime(7));
            }

            DetruireConnexionEtCommande();

            return reponse;
        }

        public override Adherent_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id,nom,prenomC,nomC,sexeC,email,adresse,dateA FROM Adherent Where id=@id";
            commande.Parameters.Add(new SqlParameter("@id",ID));
            var reader = commande.ExecuteReader();

            Adherent_DAL reponse;

            if (reader.Read())
            {
                reponse = new Adherent_DAL(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetDateTime(7));
            }
            else
            {
                throw new Exception($"pas d'Adherent à l'id {ID}");
            }


            DetruireConnexionEtCommande();

            return reponse;
        }

        public override Adherent_DAL Insert(Adherent_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO Adherent (nom,prenomC,nomC,sexeC,email,adresse,dateA) VALUES " +
           "(@nom,@prenomC,@nomC,@sexeC,@email,@adresse,@dateA); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@nom", item.Nom));
            commande.Parameters.Add(new SqlParameter("@prenomC", item.PrenomC));
            commande.Parameters.Add(new SqlParameter("@nomC", item.NomC));
            commande.Parameters.Add(new SqlParameter("@sexeC", item.SexeC));
            commande.Parameters.Add(new SqlParameter("@email", item.Email));
            commande.Parameters.Add(new SqlParameter("@adresse", item.Adresse));
            commande.Parameters.Add(new SqlParameter("@dateA", item.DateA));
            item.ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            DetruireConnexionEtCommande();

            return item;
        }

        public override Adherent_DAL Update(Adherent_DAL item)
        {

            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Adherent nom = @nom ,prenomC = @prenomC, nomC = @nomC, sexeC = @sexeC, email = @email,adresse = @adresse,dateA = @dateA where id = @id";
            commande.Parameters.Add(new SqlParameter("@nom", item.Nom));
            commande.Parameters.Add(new SqlParameter("@prenomC", item.PrenomC));
            commande.Parameters.Add(new SqlParameter("@nomC", item.NomC));
            commande.Parameters.Add(new SqlParameter("@sexeC", item.SexeC));
            commande.Parameters.Add(new SqlParameter("@email", item.Email));
            commande.Parameters.Add(new SqlParameter("@adresse", item.Adresse));
            commande.Parameters.Add(new SqlParameter("@dateA", item.DateA));
            commande.Parameters.Add(new SqlParameter("@id", item.ID));

            if (1 != (int)commande.ExecuteNonQuery()) {
                throw new Exception($"pas d'Adherent à l'id {item.ID}");
            }

            DetruireConnexionEtCommande();

            return item;
        }

        public override void Delete(Adherent_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from Adherent where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", item.ID));
            var reader = commande.ExecuteReader();


            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"Aucune occurance à l'ID {item.ID} dans la table Adherent");
            }
            DetruireConnexionEtCommande();
        }
    }
}
