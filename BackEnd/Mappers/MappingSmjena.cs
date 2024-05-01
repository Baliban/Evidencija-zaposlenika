using AutoMapper;
using BackEnd.Mappers;
using BackEnd.Models;
using System.Text.RegularExpressions;

namespace BackEnd.Mappers
{
    public class MappingSmjena : Mapping<Smjena, SmjenaDTORead, RasporedDTOInsertUpdate>
    {
        public MappingSmjena()
        {
            MapperMapReadToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Smjena, SmjenaDTORead>()
                .ConstructUsing(entitet =>
                 new SmjenaDTORead(
                    entitet.ID,
                    entitet.Tip,
                    entitet.Rasporedi == null ? null : entitet.Rasporedi.ID
                    ));
            }));



        }

    }


}
