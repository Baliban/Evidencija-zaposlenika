
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public record DjelatnikDTORead(int ID, string? Ime, string? Prezime,
        string? Odjel);

    public record DjelatnikDTOInsertUpdate(
        [Required(ErrorMessage = "Ime obavezno")]
        string? Ime,
        
        [Required(ErrorMessage = "Prezime obavezno")]
        string? Prezime,

        [Required(ErrorMessage = "Odjel obavezno")]
        string? Odjel);

      
    public record RasporedDTORead( int? ID = null, string? DjelatnikImePrezime = default,
        int? Ponedjeljak = null, int? Utorak = null, int? Srijeda = null, int? Cetvrtak = null, int? Petak = null, int? Subota = null, int? Nedjelja = null, int? Fondsati = null);
   
    public record RasporedDTOInsertUpdate(
        [Required(ErrorMessage = "Djelatnik obavezno")]
        int? DjelatnikID,
        int? Ponedjeljak = null, 
        int? Utorak = null,
        int? Srijeda = null,
        int? Cetvrtak = null,
        int? Petak = null,
        int? Subota = null,
        int? Nedjelja = null);
}
