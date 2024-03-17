namespace BackEnd.Controllers
{
    using BackEnd.Controllers;
    using BackEnd.Data;
    using BackEnd.Models;
    using Microsoft.AspNetCore.Mvc;



    // namespace BackEnd.Controllers

    [ApiController]
    [Route("api/v1/[controller]")]
    public class osobaController : ControllerBase
    {
        // Dependency injection
        // Definiraš privatno svojstvo
        private readonly EdunovaContext _context;

        // Dependency injection
        // U konstruktoru primir instancu i dodjeliš privatnom svojstvu
        public osobaController(EdunovaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.osoba.ToList());
        }
        [HttpPost]
             public IActionResult Post(osoba osobe)
        {
            _context.osoba.Add(osobe
                );
            _context.SaveChanges();
            return new JsonResult(osobe);
        }
        [HttpPost]
        [Route("{Koliko osoba:int}")]
        public IActionResult Post1(osoba osobe)
        {
            _context.osoba.Add(osobe
                );
            
            _context.SaveChanges();
            return new JsonResult(osobe);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int ID, osoba osoba
            )
        {
            var osobeIzBaze = _context.osoba.Find(ID);
            // za sada ručno, kasnije će doći Mapper
            osobeIzBaze.Ime = osoba.Ime;
            osobeIzBaze.Prezime = osoba.Prezime;
            osobeIzBaze.OIB = osoba.OIB;


            _context.osoba.Update(osobeIzBaze);
            _context.SaveChanges();

            return new JsonResult(osobeIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int ID)
        {
            var osobeIzBaze = _context.osoba.Find(ID);
            _context.osoba.Remove(osobeIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka = "Obrisano" });
        }
       

    }
}
