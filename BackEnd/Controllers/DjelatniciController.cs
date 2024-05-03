using BackEnd.Mappers;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using AutoMapper;
using System.Text.RegularExpressions;


namespace BackEnd.Controllers
{
    



    // namespace BackEnd.Controllers

    [ApiController]
    [Route("api/v1/[controller]")]
    public class DjelatniciController : EdunovaController<Djelatnik, DjelatnikDTORead, DjelatnikDTOInsertUpdate>
    {
        public DjelatniciController(EdunovaContext context) : base(context)
        {
            DbSet = _context.Djelatnici;
            _mapper = new MappingDjelatnika();
        }



        [HttpGet]
        [Route("trazi/{uvjet}")]
        public IActionResult TraziDjelatnik(string uvjet)
        {
            if (uvjet == null || uvjet.Length < 3)
            {
                return BadRequest(ModelState);
            }
            uvjet = uvjet.ToLower();
            try
            {
                IEnumerable<Djelatnik> query = _context.Djelatnici
                .Include(d => d.Odjel)
                    .ToList();
                
                var niz = uvjet.Split(" ");
                foreach (var s in uvjet.Split(" "))
                {
                    query = query.Where(p => p.Ime.ToLower().Contains(s) || p.Prezime.ToLower().Contains(s));
                }
               
                var djelatnici = query.ToList();
                return new JsonResult(_mapper.MapReadList(djelatnici));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        protected override Djelatnik NadiEntitet(int ID)
        {
            return _context.Djelatnici.Include(i => i.Odjel).FirstOrDefault(x => x.ID == ID) ?? throw new Exception("Ne postoji Odjel s šifrom " + ID + " u bazi");
        }

        protected override List<DjelatnikDTORead> UcitajSve()
        {
            var lista = _context.Djelatnici
                    .Include(d => d.Odjel)
                    .ToList();
            if (lista == null || lista.Count == 0)
            {
                throw new Exception("Ne postoje podaci u bazi");
            }
            return _mapper.MapReadList(lista);
        }

        protected override Djelatnik KreirajEntitet(DjelatnikDTOInsertUpdate dto)
        {
            var odjel = _context.Odjeli.Find(dto.OdjelID);
            if (odjel == null)
            {
                throw new Exception("Ne postoji odjel s sifrom" + dto.OdjelID + " u bazi");
            }

            var entitet = _mapper.MapInsertUpdatedFromDTO(dto);
            entitet.Ime = dto.Ime;
            entitet.Prezime = dto.Prezime;
            entitet.Odjel = odjel;
            return entitet;
        }

        protected override Djelatnik PromjeniEntitet(DjelatnikDTOInsertUpdate dto, Djelatnik entitet)
        {
            var odjel = _context.Odjeli.Find(dto.OdjelID) ?? throw new Exception("Ne postoji odjel s šifrom " + dto.OdjelID + " u bazi");

            entitet.Ime = dto.Ime;
            entitet.Prezime = dto.Prezime;
            entitet.Odjel = odjel;
            return entitet;

            
        }
        protected override void KontrolaBrisanje(Djelatnik entitet)
        {
            var entitetIzbaze = _context.Rasporedi
                .Include(x => x.Djelatnici)
            .Where(x => x.Djelatnici.ID == entitet.ID)
                .ToList();
            if (entitetIzbaze != null && entitetIzbaze.Count > 0)
            {
                StringBuilder sb = new();
                sb.Append("Djelatnik se ne može obrisati jer je postavljen na Rasporedu: ");
                foreach (var e in entitetIzbaze)
                {
                    sb.Append(e.Djelatnici).Append(", ");
                }
                throw new Exception(sb.ToString()[..^26]); // umjesto sb.ToString().Substring(0, sb.ToString().Length - 2)
            }
        }

    }
}
