using BackEnd.Controllers;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.RegularExpressions;

namespace BackEnd.Data
{
    public class EdunovaContext:DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> options)
             : base(options)
        {

        }
        public DbSet<Djelatnik> Djelatnici { get; set; }
        public DbSet<Raspored> Rasporedi { get; set; }
        public DbSet<Odjel> Odjeli { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Djelatnik>().HasOne(r => r.Odjel);
            modelBuilder.Entity<Raspored>().HasOne(r => r.Djelatnici);

        
        }
        

    }
}