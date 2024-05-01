using BackEnd.Controllers;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;

namespace BackEnd.Data
{
    public class EdunovaContext(DbContextOptions<EdunovaContext> options) : DbContext(options)
    {
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Smjena>().HasOne(r => r.Djelatnici);
            //modelBuilder.Entity<Smjena>().HasOne(r => r.Rasporedi);
            modelBuilder.Entity<Raspored>().HasOne(r => r.Djelatnici);
            //modelBuilder.Entity<Satnica>().HasOne(s => s.Djelatnici);
            modelBuilder.Entity<Satnica>(
            entityBuilder =>
            {
              entityBuilder
             .ToTable("Smjene")
             .SplitToTable(
                "Djelatnici",
                tableBuilder =>
                {
                    tableBuilder.Property(Satnica => Satnica.ID).HasColumnName("ID");
                    tableBuilder.Property(Satnica => Satnica.Ime);
                    tableBuilder.Property(Satnica => Satnica.Prezime);
                    tableBuilder.Property(Satnica => Satnica.Odjel);
                })
             .SplitToTable(
                 "Rasporedi",
                 tableBuilder =>
                 {
                     tableBuilder.Property(Satnica => Satnica.ID).HasColumnName("ID");
                     tableBuilder.Property(Satnica => Satnica.Ponedjeljak);
                     tableBuilder.Property(Satnica => Satnica.Utorak);
                     tableBuilder.Property(Satnica => Satnica.Srijeda);
                     tableBuilder.Property(Satnica => Satnica.Cetvrtak);
                     tableBuilder.Property(Satnica => Satnica.Petak);
                     tableBuilder.Property(Satnica => Satnica.Subota);
                     tableBuilder.Property(Satnica => Satnica.Nedjelja);
                     tableBuilder.Property(Satnica => Satnica.Fondsati);
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
        //public DbSet<Smjena> Smjene { get; set; }
    }
}