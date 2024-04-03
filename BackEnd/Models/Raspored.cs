using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Raspored : Entitet
    {


        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Odjel { get; set; }
        public int? Ponedjeljak { get; set; }
        public int? Utorak { get; set; }
        public int? Srijeda { get; set; }
        public int? Cetvrtak { get; set; }
        public int? Petak { get; set; }
        public int? Subota { get; set; }
        public int? Nedjelja { get; set; }

        public int? fondsati { get; set; }


    }
}
