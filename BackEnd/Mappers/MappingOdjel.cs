using AutoMapper;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BackEnd.Mappers
{
    public class MappingOdjel : Mapping<Odjel, OdjelDTORead, OdjelDTOInsertUpdate>
    {

        public MappingOdjel()
        {
            MapperMapReadToDTO = new Mapper(
            new MapperConfiguration(c =>
            {
                c.CreateMap<Odjel, OdjelDTORead>()
                .ConstructUsing(entitet =>
                 new OdjelDTORead(
                    entitet.ID,
                    entitet.Naziv
                   

                    ));
            })
            );

            MapperMapInsertUpdateToDTO = new Mapper(
              new MapperConfiguration(c =>
              {
                  c.CreateMap<Odjel, OdjelDTOInsertUpdate>()
               .ConstructUsing(entitet =>
                new OdjelDTOInsertUpdate(
                   entitet.Naziv
                   
                   ));
              })
              );
        }






    }
}