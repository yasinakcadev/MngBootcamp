using Application.Features.Fuel.Commands;
using Application.Features.Fuel.Dtos;
using Application.Features.Fuel.Models;
using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuel.Profiles
{
    internal class FuelMappingProfiles : Profile
    {
        public FuelMappingProfiles()
        {
            CreateMap<Domain.Entities.Fuel, FuelDto>().ReverseMap();
            CreateMap<Domain.Entities.Fuel, CreateFuelCommand>().ReverseMap();
            CreateMap<Domain.Entities.Fuel, FuelListItem>().ReverseMap();

            CreateMap<FuelListModel, IPaginate<Domain.Entities.Fuel>>().ReverseMap();
        }
    }
}
