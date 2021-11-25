using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raminagrobis.Metier.Service;
using RaminagrobisDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RaminagrobisAPI.Controllers
{
    [Route("reference")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ReferenceTemp> Get()
        {
            var refs = Reference.GetAll();
            var result = new List<ReferenceTemp>();
            foreach (var item in refs)
            {
                result.Add(new ReferenceTemp()
                {
                    ID = item.ID,
                    Marque = item.Marque,
                    Nom = item.Nom,
                    ReferenceO = item.Refs
                });
            }
            return result;
        }

        // GET api/<ReferenceController>/5
        [HttpGet("{id}")]
        public ReferenceTemp Get(int id)
        {
            var item = Reference.GetByID(id);
            return new ReferenceTemp()
            {
                ID = item.ID,
                Marque = item.Marque,
                Nom = item.Nom,
                ReferenceO = item.Refs
            };
        }
        [HttpPost("{idFournisseur}")]
        public void Insert(int idFournisseur, IFormFile file)
        {

            using (StreamReader reader = new StreamReader(file.OpenReadStream()))
            {
                var topline = reader.ReadLine();
                var columnName = topline.Split(";");
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    string refs = values[0];
                    string noms = values[1];
                    string marque = values[2];

                    var reference = new ReferenceTemp() { Marque = marque, Nom = noms, ReferenceO = refs };
                    Reference.Insert(reference);
                    Reference.MatchWithFournisseur(reference, idFournisseur);
                }
            }
        }


        // DELETE api/<ReferenceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Reference.Delete(id);
        }
        [HttpDelete]
        public void Delete()
        {
            Reference.DeleteAll();
        }
    }
}
