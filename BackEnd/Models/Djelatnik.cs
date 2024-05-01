using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace BackEnd.Models
{
    //[NotMapped]
    public class Djelatnik : Entitet
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Odjel { get; set; }

        [ForeignKey("SmjeneID")]
        public Smjena? Smjene { get; set; }
        //public ICollection<Satnica>? Satnice { get; } = [];

        //public ICollection<Raspored>? Rasporedi { get; } = [];



    }
}
