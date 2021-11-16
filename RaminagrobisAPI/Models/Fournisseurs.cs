using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;
using Raminagrobis.Metier;

namespace RaminagrobisAPI.Models
{
    public class Fournisseurs
    {
        public static List<string> GetAll()
        {
            var result = new List<string>();
            var depot = new FournisseurDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                var temp = ToJSON(item);
                result.Add(temp);
            }
            return result;
        }

        public static string ToJSON(Fournisseur_DAL fournisseur)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append($"{'"'}nom{'"'} : {'"'}{fournisseur.Nom}{'"'},");
            sb.Append($"{'"'}nomC{'"'} : {'"'}{fournisseur.NomC}{'"'},");
            sb.Append($"{'"'}prenomC{'"'} : {'"'}{fournisseur.PrenomC}{'"'},");
            sb.Append($"{'"'}sexeC{'"'} : {'"'}{fournisseur.SexeC}{'"'},");
            sb.Append($"{'"'}email{'"'} : {'"'}{fournisseur.Email}{'"'},");
            sb.Append($"{'"'}adresse{'"'} : {'"'}{fournisseur.Adresse}{'"'}");
            sb.Append("}");
            return sb.ToString();
        }
    }
}

    
