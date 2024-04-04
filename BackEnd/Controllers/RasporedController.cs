﻿namespace BackEnd.Controllers
{
    using BackEnd.Controllers;
    using BackEnd.Data;
    using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations;



    
    
    
    
    [ApiController]
        [Route("api/v1/[controller]")]
        public class RasporedController:ControllerBase
    {
        
    

    // Dependency injection
    // Definiraš privatno svojstvo
    private readonly EdunovaContext _context;

            // Dependency injection
            // U konstruktoru primir instancu i dodjeliš privatnom svojstvu
            public RasporedController(EdunovaContext context)
            {
                _context = context;
            }

        

        [HttpGet]
            public IActionResult Get()
            {
                return new JsonResult(_context.rasporedi.ToList());
            }

            [HttpPost]
            public IActionResult Post(Raspored tjedan)
            {
                _context.rasporedi.Add(tjedan);
                _context.SaveChanges();
                return new JsonResult(tjedan);
            }

            [HttpPut]
            [Route("{ID:int}")]
            public IActionResult Put(int ID, Raspored raspored)
            {
                var satnica = _context.rasporedi.Find(ID);
                // za sada ručno, kasnije će doći Mapper
                satnica.Ponedjeljak = raspored.Ponedjeljak;
                satnica.Utorak = raspored.Utorak;
                satnica.Srijeda = raspored.Srijeda;
                satnica.Cetvrtak = raspored.Cetvrtak;
                satnica.Petak = raspored.Petak;
                satnica.Subota = raspored.Subota;
                satnica.Nedjelja = raspored.Nedjelja;

            _context.rasporedi.Update(satnica);
                _context.SaveChanges();

                return new JsonResult(satnica);
            }

            [HttpDelete]
            [Route("{ID:int}")]
            [Produces("application/json")]
            public IActionResult Delete(int ID)
            {
                var satnica = _context.rasporedi.Find(ID);
                _context.rasporedi.Remove(satnica);
                _context.SaveChanges();
                return new JsonResult(new { poruka = "Obrisano" });
            }

        }
    }
