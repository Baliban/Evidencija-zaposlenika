
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BackEnd.Models
{
    public record DjelatnikDTORead(int ID, string? Ime, string? Prezime,
        string? Odjel, int? SmjeneID);

    public record DjelatnikDTOInsertUpdate(
        [Required(ErrorMessage = "Ime obavezno")]
        string? Ime,
        
        [Required(ErrorMessage = "Prezime obavezno")]
        string? Prezime,

        [Required(ErrorMessage = "Odjel obavezno")]
        string? Odjel);

      
    public record RasporedDTORead( int? ID, string? DjelatnikImePrezime,
        int? Ponedjeljak, int? Utorak, int? Srijeda, int? Cetvrtak, int? Petak, int? Subota, int? Nedjelja, int? Fondsati, int? SmjeneID);
   
    public record RasporedDTOInsertUpdate(
        [Required(ErrorMessage = "Djelatnik obavezno")]
        int? ImePrezime = default,
        int? Ponedjeljak = null, 
        int? Utorak = null,
        int? Srijeda = null,
        int? Cetvrtak = null,
        int? Petak = null,
        int? Subota = null,
        int? Nedjelja = null);

    public record SatnicaDTORead(int ID,string? Ime, string? Prezime ,string? Odjel, 
        int? Ponedjeljak = null, int? Utorak = null, int? Srijeda = null, int? Cetvrtak = null, int? Petak = null, int? Subota = null, int? Nedjelja = null, int? Fondsati = null);

    public record SmjenaDTORead(int ID,int? Rasporedi,int? Tip);



}
