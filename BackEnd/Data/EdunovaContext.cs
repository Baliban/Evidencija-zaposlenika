

using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class EdunovaContext:DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> options) 
            : base(options) { 

        }

        public DbSet<Djelatnik> djelatnici { get; set; }
        public DbSet<Raspored> rasporedi { get; set; }

    }
}
