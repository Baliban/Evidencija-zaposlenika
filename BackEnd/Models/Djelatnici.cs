using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Djelatnici: Entitet
    {
        public string? Ime { get; set; }
        public int? Prezime { get; set; }
        public decimal? Odjel { get; set; }

        

    }
}
