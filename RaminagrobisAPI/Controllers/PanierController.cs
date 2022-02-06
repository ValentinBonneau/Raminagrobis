using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaminagrobisDTO;
using Raminagrobis.Metier;
using Raminagrobis.Metier.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RaminagrobisAPI.Controllers
{
    [Route("panier")]
    [ApiController]
    public class PanierController : ControllerBase
    {
        [HttpGet("/Global/{semaine}/Fournisseur/{idFournisseur}")]
        public FileResult GetForFournisseur(DateTime semaine, int idFournisseur)
        {

            var lgMetier = PanierG.GetLigneByFournisseur(idFournisseur, semaine);

            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.WriteLine("reference;quantite;prix unitaire HT");
            foreach (var item in lgMetier)
            {
                sw.WriteLine($"{item.refs};{item.Quantite};0");
            }
            sw.Flush();
            ms.Position = 0;
            return new FileStreamResult(ms, "text/csv");
        }
        [HttpPost("/Global/{semaine}/Fournisseur/{idFournisseur}")]
        public void PostPrix(DateTime semaine, int idFournisseur, IFormFile file)
        {
             
            using (StreamReader reader = new StreamReader(file.OpenReadStream()))
            {
                var ListPrix = new List<PrixTemp>();
                var topline = reader.ReadLine();
                var columnName = topline.Split(";");
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(";");

                    var idLignePG = PanierG.GetByDate(semaine).LignesG.Where(l => l.refs == values[0]).First().ID;

                    ListPrix.Add(new PrixTemp()
                    {
                        IdFournisseur = idFournisseur,
                        prix = Convert.ToDouble(values[2]),
                        IdLignePanierG = idLignePG
                    });
                }
                Prix.Insert(ListPrix);
            }

        }
        [HttpGet("/Global/{semaine}/cloture")]
        public PanierGlobalTemp GetPanierCloturer(DateTime semaine)
        {
            var pannier = PanierG.GetByDate(semaine);
            var ligne = new List<LignePanierGlobalTemp>();
            var listPrix = Prix.GetByPanierG(pannier.ID);
            foreach (var item in pannier.LignesG)
            {
                ligne.Add(new LignePanierGlobalTemp()
                {
                    Quantite = item.Quantite,
                    Reference = item.refs,
                    ID = item.ID,
                    Prix = listPrix.Where(p => p.IdLignePanierG == item.ID).First()
                });
            };
            var result = new PanierGlobalTemp()
            {
                ID = pannier.ID,
                Date = pannier.Date,
                LignesG = ligne
            };
            return result;
        }

        [HttpGet("/Global/{semaine}/cloture/{idAdherent}")]
        public FileResult GetCSVPanierCloturer(DateTime semaine, int idAdherent)
        {
            var lignes = Panier.Get(idAdherent, semaine);

            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.WriteLine("reference;quantite;prix unitaire HT");
            foreach (var item in lignes)
            {
                sw.WriteLine($"{item.Refs};{item.Quantite};{item.PrixU}");
            }
            sw.Flush();
            ms.Position = 0;
            return new FileStreamResult(ms, "text/csv");

        }

        [HttpGet("/Global/{semaine}")]
        public PanierGlobalTemp Get(DateTime semaine)
        {
            var pannier = PanierG.GetByDate(semaine);
            var ligne = new List<LignePanierGlobalTemp>();
            foreach (var item in pannier.LignesG)
            {
                ligne.Add(new LignePanierGlobalTemp()
                {
                    Quantite = item.Quantite,
                    Reference = item.refs,
                    ID = item.ID
                });
            };
            var result = new PanierGlobalTemp()
            {
                ID = pannier.ID,
                Date = pannier.Date,
                LignesG = ligne
            };

            return result;
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

                    panier.Lignes.Add(new LignePanierTemp() { Ref = refs, Quantite = quantitee });
                }
            }
            Panier.Insert(panier, idAdherent);

        }
    }
}
