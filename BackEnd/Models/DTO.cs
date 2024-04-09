
using System.ComponentModel.DataAnnotations;

namespace EdunovaAPP.Models
{
    public record DjelatnikDTORead(int ID, string Ime, string Prezime,
        string Odjel);

    public record DjelatnikDTOInsertUpdate(
        [Required(ErrorMessage = "Ime obavezno")]
        string? Ime,
        
        [Required(ErrorMessage = "Prezime obavezno")]
        string Prezime,

        [Required(ErrorMessage = "Odjel obavezno")]
        string Odjel);

      
    public record RasporedDTORead( int ID, string? DjelatnikImePrezime,
        int? Ponedjeljak, int? Utorak, int? Srijeda, int? Cetvrtak, int? Petak, int? Subota, int? Nedjelja);
   
    public record RasporedDTOInsertUpdate(
        [Required(ErrorMessage = "Djelatnik obavezno")]
        string? DjelatnikImePrezime,
        [Required(ErrorMessage = "Smjer obavezno")]
        int? Ponedjeljak, 
        int? Utorak,
        int? Srijeda,
        int? Petak,
        int? Subota,
        int? Nedjelja);
}
