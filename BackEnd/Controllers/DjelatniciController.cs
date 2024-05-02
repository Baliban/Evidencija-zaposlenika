using BackEnd.Mappers;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using AutoMapper;


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
                IEnumerable<Djelatnik> query = _context.Djelatnici;
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
