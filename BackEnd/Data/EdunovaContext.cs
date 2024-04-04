

using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class EdunovaContext:DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> options) 
            : base(options) { 

        }

        public DbSet<Djelatnik> Djelatnici { get; set; }
        public DbSet<Raspored> Rasporedi { get; set; }

    }
}
