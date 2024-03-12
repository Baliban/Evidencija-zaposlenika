using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public abstract class Entitet
    {
        [Key]
        public int ID { get; set; }
    }
}
