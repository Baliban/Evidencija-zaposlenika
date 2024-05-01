using AutoMapper;
using BackEnd.Mappers;
using BackEnd.Models;
using System.Text.RegularExpressions;

namespace BackEnd.Mappers
{
    public class MappingSatnica : Mapping<Satnica, SatnicaDTORead, RasporedDTOInsertUpdate>
    {
        public MappingSatnica()
        {
            MapperMapReadToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Satnica, SatnicaDTORead>()
                .ConstructUsing(entitet =>
                 new SatnicaDTORead(
                    entitet.ID,
                    entitet.Ime,
                    entitet.Prezime,
                    entitet.Odjel,
                    entitet.Ponedjeljak,
                    entitet.Utorak,
                    entitet.Srijeda,
                    entitet.Cetvrtak,
                    entitet.Petak,
                    entitet.Subota,
                    entitet.Nedjelja,
                    entitet.Fondsati));
            }));
       

            
        }

}

    
}
