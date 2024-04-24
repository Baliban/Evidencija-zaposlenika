
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
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
        int? Ponedjeljak, int? Utorak, int? Srijeda, int? Cetvrtak, int? Petak, int? Subota, int? Nedjelja, int? Fondsati);
   
    public record RasporedDTOInsertUpdate(
        [Required(ErrorMessage = "Djelatnik obavezno")]
        int? DjelatnikID,
        int? Ponedjeljak, 
        int? Utorak,
        int? Srijeda,
        int? Cetvrtak,
        int? Petak,
        int? Subota,
        int? Nedjelja);
}
