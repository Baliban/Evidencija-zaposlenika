using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BackEnd.Models
{
    public record DjelatnikDTORead(int ID, string? Ime, string? Prezime,
        int? Odjel);

    public record DjelatnikDTOInsertUpdate(
        [Required(ErrorMessage = "Ime obavezno")]
        string? Ime,
        
        [Required(ErrorMessage = "Prezime obavezno")]
        string? Prezime,

        [Required(ErrorMessage = "Odjel obavezno")]
        int? OdjelID);

      
    public record RasporedDTORead(int ID,string? DjelatnikImePrezimeOdjel,
        int? Ponedjeljak, int? Utorak, int? Srijeda, int? Cetvrtak, int? Petak, int? Subota, int? Nedjelja);
   
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

    public record OdjelDTORead(int ID,string? Naziv);

    public record OdjelInsertUpdate(
        string? Naziv);


}
