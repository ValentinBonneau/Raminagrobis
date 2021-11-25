using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Raminagrobis.Metier.Service;
using RaminagrobisDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RaminagrobisAPI.Controllers
{
    [Route("adherent")]
    [ApiController]
    public class AdherentController : ControllerBase
    {
        // GET: api/<AdherentController>
        [HttpGet]
        public IEnumerable<AdherentTemp> Get()
        {
            var result = new List<AdherentTemp>();
            var ads = Adherent.GetAll();
            foreach (var adherent in ads)
            {
                result.Add(new AdherentTemp() {
                    Nom = adherent.Nom,
                    NomC = adherent.NomC,
                    PrenomC = adherent.PrenomC,
                    SexeC = adherent.SexeC,
                    Adresse = adherent.Adresse,
                    DateA = adherent.Date,
                    Email = adherent.Email
                });
            }
            return result;
        }

        // GET api/<AdherentController>/5
        [HttpGet("{id}")]
        public AdherentTemp Get(int id)
        {
            var adherent = Adherent.GetByID(id);
            return new AdherentTemp()
            {
                Nom = adherent.Nom,
                NomC = adherent.NomC,
                PrenomC = adherent.PrenomC,
                SexeC = adherent.SexeC,
                Adresse = adherent.Adresse,
                DateA = adherent.Date,
                Email = adherent.Email
            };
        }

        // POST api/<AdherentController>
        [HttpPost]
        public void Post([FromBody] AdherentTemp adherent)
        {
            Adherent.Insert(adherent);
        }

        // PUT api/<AdherentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AdherentTemp adherent)
        {
            Adherent.Edit(id, adherent);
        }

        // DELETE api/<AdherentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Adherent.Delete(id);
        }
    }
}
