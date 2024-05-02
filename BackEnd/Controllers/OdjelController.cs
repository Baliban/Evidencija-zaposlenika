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
    public class OdjelController : EdunovaController<Odjel, OdjelDTORead, OdjelInsertUpdate>
    {
        public OdjelController(EdunovaContext context) : base(context)
        {
            DbSet = _context.Odjeli;
           
        }
                
        protected override void KontrolaBrisanje(Odjel entitet)
        {
            //var entitetIzbaze = _context.Djelatnici
            //    .Include(x => x.Odjel)
            //.Where(x => x.Odjel.ID == entitet.ID)
            //    .ToList();
            //if (entitetIzbaze != null && entitetIzbaze.Count > 0)
            //{
            //    StringBuilder sb = new();
            //    sb.Append("Odjel se ne može obrisati jer postoje djelatnici u istom odjelu: ");
            //    foreach (var e in entitetIzbaze)
            //    {
            //        sb.Append(e.Odjel).Append(", ");
            //    }
            //    throw new Exception(sb.ToString()[..^26]); 
            //}
        }

    }
}
