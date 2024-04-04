using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    



    // namespace BackEnd.Controllers

    [ApiController]
    [Route("api/v1/[controller]")]
    public class DjelatniciController:ControllerBase
    {
        // Dependency injection
        // Definiraš privatno svojstvo
        private readonly EdunovaContext _context;

        // Dependency injection
        // U konstruktoru primir instancu i dodjeliš privatnom svojstvu
        public DjelatniciController(EdunovaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Djelatnici.ToList());
        }

        [HttpGet]
        [Route("{ID:int}")]
        public IActionResult GetBySifra(int ID)
        {
            return new JsonResult(_context.Djelatnici.Find(ID));
        }

        [HttpPost]
        public IActionResult Post(Djelatnik djelatnik)
        {
            _context.Djelatnici.Add(djelatnik);
            _context.SaveChanges();
            return new JsonResult(djelatnik);
        }

        [HttpPut]
        [Route("{ID:int}")]
        public IActionResult Put(int ID, Djelatnik djelatnik)
        {
            var djelatnikIzBaze = _context.Djelatnici.Find(ID);
            // za sada ručno, kasnije će doći Mapper
            djelatnikIzBaze.Ime = djelatnik.Ime;
            djelatnikIzBaze.Prezime = djelatnik.Prezime;
            djelatnikIzBaze.Odjel = djelatnik.Odjel;


            _context.Djelatnici.Update(djelatnikIzBaze);
            _context.SaveChanges();

            return new JsonResult(djelatnikIzBaze);
        }

        [HttpDelete]
        [Route("{ID:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int ID)
        {
            var djelatnikIzBaze = _context.Djelatnici.Find(ID);
            _context.Djelatnici.Remove(djelatnikIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka = "Obrisano" });
        }

    }
}
