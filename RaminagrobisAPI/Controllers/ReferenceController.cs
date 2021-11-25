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
    [Route("reference")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        // GET: api/<ReferenceController>
        [HttpGet]
        public IEnumerable<ReferenceTemp> Get()
        {
            return Reference.GetAll();
        }

        // GET api/<ReferenceController>/5
        [HttpGet("{id}")]
        public ReferenceTemp Get(int id)
        {
            return Reference.GetByID(id);
        }

        // POST api/<ReferenceController>
        [HttpPost]
        public void Post([FromBody] ReferenceTemp reference)
        {
            Reference.Insert(reference);
        }

        // PUT api/<ReferenceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ReferenceTemp reference)
        {
            Reference.Edit(id, reference);
        }

        // DELETE api/<ReferenceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Reference.Delete(id);
        }
    }
}
