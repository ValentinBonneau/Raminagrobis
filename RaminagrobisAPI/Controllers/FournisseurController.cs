﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raminagrobis.DAL;
using Raminagrobis.DAL.Depot;
using RaminagrobisAPI.Models;
using RaminagrobisAPI.Tampon;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RaminagrobisAPI.Controllers
{
    [Route("fourniseurs")]
    [ApiController]
    public class FournisseurController : ControllerBase
    {
        // GET: api/<FournisseurController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return Fournisseurs.GetAll();
        }

        // GET api/<FournisseurController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return Fournisseurs.GetByID(id);
        }

        // POST api/<FournisseurController>
        [HttpPost]
        public void Post([FromBody] FournisseurTemp fournisseur)
        {
            Fournisseurs.Insert(fournisseur);
        }

        // PUT api/<FournisseurController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FournisseurController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
