using AutoMapper;
using BackEnd.Mappers;
using BackEnd.Models;
using System.Text.RegularExpressions;

namespace BackEnd.Mappers
{
    public class MappingGrupa : Mapping<Raspored, RasporedDTORead, RasporedDTOInsertUpdate>
    {

        public MappingGrupa()
        {
            MapperMapReadToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Raspored, RasporedDTORead>()
                .ConstructUsing(entitet =>
                 new RasporedDTORead(
                    entitet.ID,
                    entitet.Djelatnik == null ? "" : (entitet.Djelatnik.Ime
                        + " " + entitet.Djelatnik.Prezime).Trim(),
                    entitet.Ponedjeljak,
                    entitet.Utorak,
                    entitet.Srijeda,
                    entitet.Cetvrtak,
                    entitet.Petak,
                    entitet.Subota,
                    entitet.Nedjelja,
                    entitet.Fondsati!.Count()));
            }));

            MapperMapInsertUpdatedFromDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<RasporedDTOInsertUpdate, Raspored>();
            }));

            MapperMapInsertUpdateToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Raspored, RasporedDTOInsertUpdate>()
                .ConstructUsing(entitet =>
                 new RasporedDTOInsertUpdate(
                    entitet.Djelatnik == null ? null : entitet.Djelatnik.ID,
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
