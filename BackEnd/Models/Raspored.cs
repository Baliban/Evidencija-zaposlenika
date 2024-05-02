using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{

    public class Raspored : Entitet
    {

        [ForeignKey("djelatnik")]
        public Djelatnik? Djelatnici { get; set; }
      
        public int? Ponedjeljak { get; set; }
        public int? Utorak { get; set; }
        public int? Srijeda { get; set; }
        public int? Cetvrtak { get; set; }
        public int? Petak { get; set; }
        public int? Subota { get; set; }
        public int? Nedjelja { get; set; }
  
    }
}
