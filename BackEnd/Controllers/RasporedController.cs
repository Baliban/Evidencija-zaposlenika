 
    using BackEnd.Data;
    using BackEnd.Models;
    using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers

{  
    
    
    
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
                return new JsonResult(_context.Rasporedi.ToList());
            }

            [HttpPost]
            public IActionResult Post(Raspored raspored)
            {
                _context.Rasporedi.Add(raspored);
                _context.SaveChanges();
                return new JsonResult(raspored);
            }

            [HttpPut]
            [Route("{ID:int}")]
            public IActionResult Put(int ID, Raspored raspored)
            {
                var satnica = _context.Rasporedi.Find(ID);
                satnica.Djelatnik = raspored.Djelatnik;
                satnica.Ponedjeljak = raspored.Ponedjeljak;
                satnica.Utorak = raspored.Utorak;
                satnica.Srijeda = raspored.Srijeda;
                satnica.Cetvrtak = raspored.Cetvrtak;
                satnica.Petak = raspored.Petak;
                satnica.Subota = raspored.Subota;
                satnica.Nedjelja = raspored.Nedjelja;

            _context.Rasporedi.Update(satnica);
                _context.SaveChanges();

                return new JsonResult(satnica);
            }

     


        [HttpDelete]
            [Route("{ID:int}")]
            [Produces("application/json")]
            public IActionResult Delete(int ID)
            {
                var satnica = _context.Rasporedi.Find(ID);
                _context.Rasporedi.Remove(satnica);
                _context.SaveChanges();
                return new JsonResult(new { poruka = "Obrisano" });
            }

        }
    }
