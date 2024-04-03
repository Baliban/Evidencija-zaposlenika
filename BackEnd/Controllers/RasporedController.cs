namespace BackEnd.Controllers
{
    using BackEnd.Controllers;
    using BackEnd.Data;
    using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations;



    
    
    
    
    [ApiController]
        [Route("api/v1/[controller]")]
        public class RasporedController:ControllerBase
    {
        
    

    // Dependency injection
    // Definiraš privatno svojstvo
    private readonly EdunovaContext _context;

            // Dependency injection
            // U konstruktoru primir instancu i dodjeliš privatnom svojstvu
            public RasporedController(EdunovaContext context)
            {
                _context = context;
            }

        

        [HttpGet]
            public IActionResult Get()
            {
                return new JsonResult(_context.Raspored.ToList());
            }

            [HttpPost]
            public IActionResult Post(Raspored tjedan)
            {
                _context.Raspored.Add(tjedan);
                _context.SaveChanges();
                return new JsonResult(tjedan);
            }

            [HttpPut]
            [Route("{ID:int}")]
            public IActionResult Put(int ID, Raspored Raspored)
            {
                var satnica = _context.Raspored.Find(ID);
                // za sada ručno, kasnije će doći Mapper
                satnica.Ponedjeljak = Raspored.Ponedjeljak;
                satnica.Utorak = Raspored.Utorak;
                satnica.Srijeda = Raspored.Srijeda;
                satnica.Cetvrtak = Raspored.Cetvrtak;
                satnica.Petak = Raspored.Petak;
                satnica.Subota = Raspored.Subota;
                satnica.Nedjelja = Raspored.Nedjelja;

            _context.Raspored.Update(satnica);
                _context.SaveChanges();

                return new JsonResult(satnica);
            }

            [HttpDelete]
            [Route("{ID:int}")]
            [Produces("application/json")]
            public IActionResult Delete(int ID)
            {
                var satnica = _context.Raspored.Find(ID);
                _context.Raspored.Remove(satnica);
                _context.SaveChanges();
                return new JsonResult(new { poruka = "Obrisano" });
            }

        }
    }
