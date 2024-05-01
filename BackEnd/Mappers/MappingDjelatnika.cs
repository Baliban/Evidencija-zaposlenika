using AutoMapper;
using BackEnd.Models;

namespace BackEnd.Mappers
{
    public class MappingDjelatnika : Mapping<Djelatnik, DjelatnikDTORead, DjelatnikDTOInsertUpdate>
    {

        public MappingDjelatnika()
        {
            MapperMapReadToDTO = new Mapper(
            new MapperConfiguration(c =>
            {
                c.CreateMap<Djelatnik, DjelatnikDTORead>()
                .ConstructUsing(entitet =>
                 new DjelatnikDTORead(
                    entitet.ID,
                    entitet.Ime,
                    entitet.Prezime,
                    entitet.Odjel,
                    entitet.Smjene == null ? null : entitet.Smjene.ID


                    ));
            })
            );

            MapperMapInsertUpdateToDTO = new Mapper(
              new MapperConfiguration(c =>
              {
                  c.CreateMap<Djelatnik, DjelatnikDTOInsertUpdate>()
               .ConstructUsing(entitet =>
                new DjelatnikDTOInsertUpdate(
                   entitet.Ime,
                   entitet.Prezime,
                   entitet.Odjel
                   ));
              })
              );
        }


       



    }
}