using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.IO;

namespace BackEnd.Models
{
    public class Satnica : Entitet
    {

        [ForeignKey("raspored")]
        public Raspored? Rasporedi { get; set; }

        [ForeignKey("djelatnik")]
        public Djelatnik? Djelatnici { get;  }
        public string? Ime { get; }
        public string? Prezime { get; }
        public string? Odjel { get; }
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
