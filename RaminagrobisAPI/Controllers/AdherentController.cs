using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RaminagrobisAPI.Models;
using RaminagrobisAPI.Tampon;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RaminagrobisAPI.Controllers
{
    [Route("adherent")]
    [ApiController]
    public class AdherentController : ControllerBase
    {
        // GET: api/<AdherentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Adherent.GetAll();
        }

        // GET api/<AdherentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return Adherent.GetByID(id);
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
