 
    using BackEnd.Data;
    using BackEnd.Models;
    using Microsoft.AspNetCore.Mvc;
    using BackEnd.Mappers;
    using Microsoft.EntityFrameworkCore;
    using System.Text;
using System.Text.RegularExpressions;

namespace BackEnd.Controllers

{  
    
    
    
    [ApiController]
    [Route("api/v1/[controller]")]
        public class RasporedController : EdunovaController<Raspored, RasporedDTORead, RasporedDTOInsertUpdate>
    {

        public RasporedController(EdunovaContext context) : base(context)
        {
            DbSet = _context.Rasporedi;
            _mapper = new MappingRaspored();
        }
        protected override void KontrolaBrisanje(Raspored entitet)
        {

        }


        [HttpGet]
        [Route("Djelatnici/{RasporediID:int}")]
        public IActionResult GetDjelatnici(int IDRasporeda)
        {
            if (!ModelState.IsValid || IDRasporeda <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var p = _context.Rasporedi
                    .Include(i => i.Djelatnici).FirstOrDefault(x => x.ID == IDRasporeda);
                if (p == null)
                {
                    return BadRequest("Ne postoji raspored s šifrom " + IDRasporeda + " u bazi");
                }
                var mapping = new Mapping<Djelatnik, DjelatnikDTORead, DjelatnikDTOInsertUpdate>();
                return new JsonResult(p.Djelatnici);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("{ID:int}/dodaj/{DjelatnikID:int}")]
        public IActionResult DodajDjelatnika(int ID, int DjelatnikID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ID <= 0 || DjelatnikID <= 0)
            {
                return BadRequest("Šifra rasporeda ili djelatnika nije dobra");
            }
            try
            {
                var raspored = _context.Rasporedi
                    .Include(r => r.Djelatnici)
                    .FirstOrDefault(r => r.ID == ID);
                if (raspored == null)
                {
                    return BadRequest("Ne postoji raspored s šifrom " + ID + " u bazi");
                }
                var djelatnik = _context.Djelatnici.Find(DjelatnikID);
                if (djelatnik == null)
                {
                    return BadRequest("Ne postoji djelatnik s šifrom " + DjelatnikID + " u bazi");
                }
                _context.Djelatnici.Add(djelatnik);
                _context.Rasporedi.Update(raspored);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(
                       StatusCodes.Status503ServiceUnavailable,
                       ex.Message);
            }
        }


        [HttpPut]
            [Route("{IDDjelatnik:int}")]
            public IActionResult Put(int ID, Raspored raspored)
            {
                var satnica = _context.Rasporedi.Find(ID);
                satnica.Djelatnici = raspored.Djelatnici;
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
        [Route("{ID:int}/obrisi/{djelatnikID:int}")]
        public IActionResult ObrisiDjelatnika(int ID, int djelatnikID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ID <= 0 || djelatnikID <= 0)
            {
                return BadRequest("Šifra rasporeda ili djelatnika nije dobra");
            }
            try
            {
                var raspored = _context.Rasporedi
                    .Include(r => r.Djelatnici)
                    .FirstOrDefault(r => r.ID == ID);
                if (raspored == null)
                {
                    return BadRequest("Ne postoji grupa s šifrom " + ID + " u bazi");
                }
                var djelatnik = _context.Djelatnici.Find(djelatnikID);
                if (djelatnik == null)
                {
                    return BadRequest("Ne postoji polaznik s šifrom " + djelatnikID + " u bazi");
                }
                raspored.Djelatnici = null;
                _context.Rasporedi.Update(raspored);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }




        protected override Raspored KreirajEntitet(RasporedDTOInsertUpdate dto)
        {
            var djelatnik = _context.Djelatnici.Find(dto.DjelatnikID) ?? throw new Exception("Ne postoji djelatnik s šifrom " + dto.DjelatnikID + " u bazi");
            var entitet = _mapper.MapInsertUpdatedFromDTO(dto);
            entitet.Djelatnici = djelatnik; 
            return entitet;
        }

        protected override List<RasporedDTORead> UcitajSve()
        {
            var lista = _context.Rasporedi
                    .Include(r => r.Djelatnici)
                    .ToList();
            if (lista == null || lista.Count == 0)
            {
                throw new Exception("Ne postoje podaci u bazi");
            }
            return _mapper.MapReadList(lista);
        }

        protected override Raspored NadiEntitet(int ID)
        {
            return _context.Rasporedi.Include(i => i.Djelatnici)
                    .Include(i => i.Djelatnici).FirstOrDefault(x => x.ID == ID) ?? throw new Exception("Ne postoji Raspored s šifrom " + ID + " u bazi");
        }



        protected override Raspored PromjeniEntitet(RasporedDTOInsertUpdate dto, Raspored entitet)
        {
            var djelatnik = _context.Djelatnici.Find(dto.DjelatnikID) ?? throw new Exception("Ne postoji Djelatnik s šifrom " + dto.DjelatnikID + " u bazi");



           
            entitet.Ponedjeljak = dto.Ponedjeljak;
            entitet.Utorak = dto.Utorak;
            entitet.Srijeda = dto.Srijeda;
            entitet.Cetvrtak = dto.Cetvrtak;
            entitet.Petak = dto.Petak;
            entitet.Subota = dto.Subota;
            entitet.Nedjelja = dto.Nedjelja;
           

            return entitet;

        }

    }
    }
