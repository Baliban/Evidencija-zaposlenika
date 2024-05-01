using BackEnd.Controllers;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.RegularExpressions;

namespace BackEnd.Data
{
    public class EdunovaContext(DbContextOptions<EdunovaContext> options) : DbContext(options)
    {

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Djelatnik>().HasOne(r => r.Smjene);
            modelBuilder.Entity<Raspored>().HasOne(r => r.Smjene);
            modelBuilder.Entity<Smjena>().HasOne(r => r.Rasporedi);
            modelBuilder.Entity<Raspored>().HasOne(r => r.Djelatnici);
             
             modelBuilder.Entity<Satnica>(
             eb =>
             {
                 eb
             .ToTable("Smjene")
             .SplitToTable(
                "Djelatnici",
                tb =>
                {
                    tb.Property(Satnica => Satnica.ID).HasColumnName("ID");
                    tb.Property(Satnica => Satnica.Ime);
                    tb.Property(Satnica => Satnica.Prezime);
                    tb.Property(Satnica => Satnica.Odjel);
                })
            .SplitToTable(
                "Rasporedi",
                tb =>
                 {
                     tb.Property(Satnica => Satnica.ID).HasColumnName("ID");
                     tb.Property(Satnica => Satnica.Ponedjeljak);
                     tb.Property(Satnica => Satnica.Utorak);
                     tb.Property(Satnica => Satnica.Srijeda);
                     tb.Property(Satnica => Satnica.Cetvrtak);
                     tb.Property(Satnica => Satnica.Petak);
                     tb.Property(Satnica => Satnica.Subota);
                     tb.Property(Satnica => Satnica.Nedjelja);
                     tb.Property(Satnica => Satnica.Fondsati);
                 });
             });
             modelBuilder.Entity<Satnica>()
            .HasOne<Satnica>()
           .WithOne()
           .HasForeignKey<Satnica>(a => a.ID);
            //.OnDelete(DeleteBehavior.Restrict);



        }
        public DbSet<Djelatnik> Djelatnici { get; set; }
        public DbSet<Raspored> Rasporedi { get; set; }
        public DbSet<Smjena> Smjene { get; set; }
    }
}