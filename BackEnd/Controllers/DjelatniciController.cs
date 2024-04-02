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
        public IActionResult Post(Djelatnici smjer)
        {
            _context.Djelatnici.Add(smjer);
            _context.SaveChanges();
            return new JsonResult(smjer);
        }

        [HttpPut]
        [Route("{ID:int}")]
        public IActionResult Put(int ID, Djelatnici Djelatnici)
        {
            var smjerIzBaze = _context.Djelatnici.Find(ID);
            // za sada ručno, kasnije će doći Mapper
            smjerIzBaze.Ime = Djelatnici.Ime;
            smjerIzBaze.Prezime = Djelatnici.Prezime;
            smjerIzBaze.Odjel = Djelatnici.Odjel;


            _context.Djelatnici.Update(smjerIzBaze);
            _context.SaveChanges();

            return new JsonResult(smjerIzBaze);
        }

        [HttpDelete]
        [Route("{ID:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int ID)
        {
            var smjerIzBaze = _context.Djelatnici.Find(ID);
            _context.Djelatnici.Remove(smjerIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka = "Obrisano" });
        }

    }
}
