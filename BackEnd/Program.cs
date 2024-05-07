using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            builder.Services.AddAutoMapper(typeof(Program));
            // Dodavanje baze podataka
            builder.Services.AddDbContext<EdunovaContext>(o => {
                o.UseSqlServer(builder.Configuration.GetConnectionString("EdunovaContext"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
            app.UseSwaggerUI();
            //{
             //   o.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                //o.EnableTryItOutByDefault();
            //});
           // }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            

            app.MapControllers();

            app.UseCors("CorsPolicy");

            //za potrebe produkcije
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.MapFallbackToFile("index.html");
            //zavrsio potrebe produkcije

            app.Run();
        }
    }
}
