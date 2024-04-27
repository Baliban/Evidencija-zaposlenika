using AutoMapper;
using BackEnd.Mappers;
using BackEnd.Models;
using System.Text.RegularExpressions;

namespace BackEnd.Mappers
{
    public class MappingRaspored : Mapping<Raspored, RasporedDTORead, RasporedDTOInsertUpdate>
    {

        public MappingRaspored()
        {
            MapperMapReadToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Raspored, RasporedDTORead>()
                .ConstructUsing(entitet =>
                 new RasporedDTORead(
                    entitet.ID,
                    entitet.Djelatnici.Ime + " " + entitet.Djelatnici.Prezime.Trim(),
                    entitet.Ponedjeljak,
                    entitet.Utorak,
                    entitet.Srijeda,
                    entitet.Cetvrtak,
                    entitet.Petak,
                    entitet.Subota,
                    entitet.Nedjelja,
                    entitet.Fondsati));
            }));

            MapperMapInsertUpdatedFromDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<RasporedDTOInsertUpdate, Raspored>();
            }));

            MapperMapInsertUpdateToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Raspored, RasporedDTOInsertUpdate>()
                .ConstructUsing(entitet =>
                 new RasporedDTOInsertUpdate(
                    entitet.Djelatnici.ID,
                    entitet.Ponedjeljak,
                    entitet.Utorak,
                    entitet.Srijeda,
                    entitet.Cetvrtak,
                    entitet.Petak,
                    entitet.Subota,
                    entitet.Nedjelja));
            }));
        }



    }
}
