using BackEnd.Controllers;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;

namespace BackEnd.Data
{
    public class EdunovaContext(DbContextOptions<EdunovaContext> options) : DbContext(options)
    {
        public DbSet<Djelatnik> Djelatnici { get; set; }
        public DbSet<Raspored> Rasporedi { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // implementacija veze 1:n
             modelBuilder.Entity<Raspored>().HasOne(r => r.Djelatnici);
            

        }
    }
}