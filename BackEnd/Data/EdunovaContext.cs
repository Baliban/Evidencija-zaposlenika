

using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BackEnd.Data
{
    public class EdunovaContext:DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> options) 
            : base(options) { 

        }

        public DbSet<Djelatnik> Djelatnici { get; set; }
        public DbSet<Raspored> Rasporedi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // implementacija veze 1:n
            modelBuilder.Entity<Raspored>().HasOne(g => g.Djelatnik);
            

        }
    }
}