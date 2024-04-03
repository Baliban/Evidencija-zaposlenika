namespace BackEnd.Controllers
{
    using BackEnd.Controllers;
    using BackEnd.Data;
    using BackEnd.Models;
    using Microsoft.AspNetCore.Mvc;



    // namespace BackEnd.Controllers

    [ApiController]
    [Route("api/v1/[controller]")]
    public class DjelatniciController : ControllerBase
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

        [HttpPost]
        public IActionResult Post(Djelatnici djelatnici)
        {
            _context.Djelatnici.Add(djelatnici);
            _context.SaveChanges();
            return new JsonResult(djelatnici);
        }

        [HttpPut]
        [Route("{ID:int}")]
        public IActionResult Put(int ID, Djelatnici Djelatnici)
        {
            var djelatnikIzBaze = _context.Djelatnici.Find(ID);
            // za sada ručno, kasnije će doći Mapper
            djelatnikIzBaze.Ime = Djelatnici.Ime;
            djelatnikIzBaze.Prezime = Djelatnici.Prezime;
            djelatnikIzBaze.Odjel = Djelatnici.Odjel;


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
