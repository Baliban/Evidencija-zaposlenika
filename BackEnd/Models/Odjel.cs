using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Odjel : Entitet
    {
        public string? Naziv { get; set; }
    }
}
