﻿using AutoMapper;
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
                    entitet.Djelatnici == null ? "" : (entitet.Djelatnici.Ime
                        + " " + entitet.Djelatnici.Prezime + " " + entitet.Djelatnici.Odjel).Trim(),
                    entitet.Ponedjeljak,
                    entitet.Utorak,
                    entitet.Srijeda,
                    entitet.Cetvrtak,
                    entitet.Petak,
                    entitet.Subota,
                    entitet.Nedjelja));
            }));

            MapperMapInsertUpdatedFromDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<RasporedDTOInsertUpdate, Raspored>();
            }));

            MapperMapInsertUpdateToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Raspored, RasporedDTOInsertUpdate>()
                .ConstructUsing(entitet =>
                 new RasporedDTOInsertUpdate(
                    entitet.Djelatnici == null ? null : entitet.Djelatnici.ID,
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
