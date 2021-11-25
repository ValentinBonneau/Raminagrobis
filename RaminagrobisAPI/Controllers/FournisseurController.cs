using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raminagrobis.Metier.Service;
using RaminagrobisDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RaminagrobisAPI.Controllers
{
    [Route("fournisseurs")]
    [ApiController]
    public class FournisseurController : ControllerBase
    {
        // GET: api/<FournisseurController>
        [HttpGet]
        public IEnumerable<FournisseurTemp> Get()
        {
            var result = new List<FournisseurTemp>();
            var fours = Fournisseurs.GetAll();
            foreach (var fournisseur in fours)
            {
                result.Add(new FournisseurTemp()
                {
                    ID = fournisseur.ID,
                    Nom = fournisseur.Nom,
                    NomC = fournisseur.NomC,
                    PrenomC = fournisseur.PrenomC,
                    Adresse = fournisseur.Adresse,
                    Email = fournisseur.Email,
                    SexeC = fournisseur.SexeC
                });
            }
            return result;
        }

        // GET api/<FournisseurController>/5
        [HttpGet("{id}")]
        public FournisseurTemp Get(int id)
        {
            var fournisseur = Fournisseurs.GetByID(id);
            return new FournisseurTemp()
            {
                ID = fournisseur.ID,
                Nom = fournisseur.Nom,
                NomC = fournisseur.NomC,
                PrenomC = fournisseur.PrenomC,
                Adresse = fournisseur.Adresse,
                Email = fournisseur.Email,
                SexeC = fournisseur.SexeC
            };
        }

        // POST api/<FournisseurController>
        [HttpPost]
        public void Post([FromBody] FournisseurTemp fournisseur)
        {
            Fournisseurs.Insert(fournisseur);
        }

        // PUT api/<FournisseurController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FournisseurTemp fournisseur)
        {
            Fournisseurs.Edit(id, fournisseur);
        }

        // DELETE api/<FournisseurController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Fournisseurs.Delete(id);
        }
       
    }
}
