using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BackEnd.Models
{
    public class Djelatnik : Entitet
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        
        [ForeignKey("odjel")]
        public Odjel? Odjel { get; set; }

        
    }
}
