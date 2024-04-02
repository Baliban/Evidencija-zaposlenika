using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using Microsoft.AspNetCore.Hosting.Builder;
using System.Reflection.Metadata;
namespace BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(opcije =>
            {
                opcije.AddPolicy("CorsPolicy",
                    builder =>
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                );

            });

            // Dodavanje baze podataka
            builder.Services.AddDbContext<EdunovaContext>(o => {
                o.UseSqlServer(builder.Configuration.GetConnectionString("EdunovaContext"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
           // if (app.Environment.IsDevelopment())
           // {
                app.UseSwagger();
                app.UseSwaggerUI();
           // }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("CorsPolicy");

            app.MapControllers();

            //za potrebe produkcije
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.MapFallbackToFile("index.html");
            //zavrsio potrebe produkcije

            app.Run();
        }
    }
}
