using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.IO;

namespace BackEnd.Models
{
    public class Satnica : Entitet
    {
        
        public string? Ime { get; set; } 
        public string? Prezime { get; set; }
        public string? Odjel { get; set; }
        //public string? Djelatnici { get; } 
        public int? Ponedjeljak { get; }
        public int? Utorak { get; }
        public int? Srijeda { get; }
        public int? Cetvrtak { get; } 
        public int? Petak { get; } 
        public int? Subota { get; } 
        public int? Nedjelja { get; } 
        public int? Fondsati { get; } 
        
    }
}
