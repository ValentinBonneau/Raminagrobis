using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Raminagrobis.DAL.Depot
{
    public class ReferenceDepot_DAL : Depot_DAL<Reference_DAL>
    {
        public override List<Reference_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, ref, nom, marque from Reference";
            var reader = commande.ExecuteReader();

            var listeDePanierG = new List<Reference_DAL>();

            var depotFour = new FournisseurDepot_DAL(); 

            while (reader.Read())
            {
                var Four = depotFour.GetAllByIDRef(reader.GetInt32(0));

                var p = new Reference_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        Four
                                         );

                listeDePanierG.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDePanierG;

        }

        public Reference_DAL GetByRef(string refs)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, ref, nom, marque from Reference where ref=@ref ";
            commande.Parameters.Add(new SqlParameter("@ref", refs));
            var reader = commande.ExecuteReader();

            var depotFour = new FournisseurDepot_DAL();

            Reference_DAL reponse;

            if (reader.Read())
            {
                var Four = depotFour.GetAllByIDRef(reader.GetInt32(0));

                reponse = new Reference_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        Four
                                        );
            }
            else
            {
                throw new Exception($"Pas de Reference ?? l'id {refs}");
            }

            DetruireConnexionEtCommande();

            return reponse;
        }

        public override Reference_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, ref, nom, marque from Reference where id=@id ";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            var depotFour = new FournisseurDepot_DAL();

            Reference_DAL reponse;

            if (reader.Read())
            {
                var Four = depotFour.GetAllByIDRef(reader.GetInt32(0));

                reponse = new Reference_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        Four
                                        ); 
            }
            else
            {
                throw new Exception($"Pas de Reference ?? l'id {ID}");
            }

            DetruireConnexionEtCommande();

            return reponse;
        }

        public override Reference_DAL Insert(Reference_DAL item)
        {
            CreerConnexionEtCommande();
            var dejaPresent = false;
            commande.CommandText = "select id from Reference where ref = @ref and nom = @nom and marque = @marque ";
            commande.Parameters.Add(new SqlParameter("@ref", item.Reference));
            commande.Parameters.Add(new SqlParameter("@nom", item.Nom));
            commande.Parameters.Add(new SqlParameter("@marque", item.Marque));
            var reader = commande.ExecuteReader();
            if (reader.Read())
            {
                item.ID = reader.GetInt32(0);
            }
            DetruireConnexionEtCommande();
            if (!dejaPresent)
            {
                CreerConnexionEtCommande();
                commande.CommandText = "insert into Reference(ref, nom, marque)" + " values (@ref, @nom, @marque); select scope_identity()";
                commande.Parameters.Add(new SqlParameter("@ref", item.Reference));
                commande.Parameters.Add(new SqlParameter("@nom", item.Nom));
                commande.Parameters.Add(new SqlParameter("@marque", item.Marque));
                var id = Convert.ToInt32((decimal)commande.ExecuteScalar());

                item.ID = id;

                DetruireConnexionEtCommande();
            }
            return item;
        }

        public override Reference_DAL Update(Reference_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Reference SET ref = @ref, nom = @nom, marque = @marque where id = @id";

            commande.Parameters.Add(new SqlParameter("@date", item.Reference));

            commande.Parameters.Add(new SqlParameter("@ref", item.Reference));

            commande.Parameters.Add(new SqlParameter("@nom", item.Nom));
            commande.Parameters.Add(new SqlParameter("@marque", item.Marque));

            commande.Parameters.Add(new SqlParameter("@id", item.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre ?? jour le Reference d'ID {item.ID}");
            }


            DetruireConnexionEtCommande();

            return item;
        }

        public override void Delete(Reference_DAL item)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from Reference where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", item.ID));
            


            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"Aucune occurance ?? l'ID {item.ID} dans la table Reference");
            }
            DetruireConnexionEtCommande();
        }
    }
}

