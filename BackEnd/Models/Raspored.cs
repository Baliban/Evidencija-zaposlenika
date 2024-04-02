using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Raspored : Entitet
    {
       

        public string? ime { get; set; }
        public string? prezime { get; set; }

        public string? Odjel { get; set; }
        public string? Ponedjeljak { get; set; }
        public string? Utorak { get; set; }
        public string? Srijeda { get; set; }
        public string? Cetvrtak { get; set; }
        public string? Petak { get; set; }
        public string? Subota { get; set; }
        public string? Nedjelja { get; set; }

        public int? fondsati { get; set; }


    }
}
