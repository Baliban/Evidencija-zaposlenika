using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Djelatnik: Entitet
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Odjel { get; set; }

        

    }
}
