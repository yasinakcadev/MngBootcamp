using Application.Features.Fuels.Commands;
using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Profiles
{
    internal class FuelMappingProfiles : Profile
    {
        public FuelMappingProfiles()
        {
            CreateMap<Fuel, FuelDto>().ReverseMap();
            CreateMap<Fuel, CreateFuelCommand>().ReverseMap();
            CreateMap<Fuel, FuelListItem>().ReverseMap();
            CreateMap<Fuel,UpdateFuelCommand>().ReverseMap();   
            CreateMap<FuelListModel, IPaginate<Fuel>>().ReverseMap();
        }
    }
}
