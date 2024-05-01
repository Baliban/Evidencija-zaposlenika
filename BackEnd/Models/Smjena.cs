using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Smjena : Entitet
    {


        [ForeignKey("raspored")]
        public Raspored? Rasporedi { get; set; }
        public int? Tip { get; set; }
        

    }
}
