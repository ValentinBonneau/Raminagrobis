using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaminagrobisDTO;
using Raminagrobis.Metier.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RaminagrobisAPI.Controllers
{
    [Route("panier")]
    [ApiController]
    public class PanierController : ControllerBase
    {
        // GET: api/<PanierController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PanierController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PanierController>
        [HttpPost("{idAdherent}")]
        public void Post(int idAdherent, IFormFile file)
        {
            PanierTemp panier = new PanierTemp() { Lignes = new List<LignePanierTemp>() };
            using (StreamReader reader = new StreamReader(file.OpenReadStream()))
            {
                var topline = reader.ReadLine();
                var columnName = topline.Split(";");
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(";");

                    string refs = values[0];
                    int quantitee = Int32.Parse(values[1]);

                    panier.Lignes.Add(new LignePanierTemp() { Ref = refs , Quantite = quantitee }) ;
                }
            }
            Panier.Insert(panier, idAdherent);
        }
        // PUT api/<PanierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<PanierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
