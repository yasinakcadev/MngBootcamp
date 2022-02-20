using Application.Features.Cities.Commands;
using Application.Features.Cities.Dtos;
using Application.Features.Cities.Models;
using Application.Features.Color.Commands;
using Application.Features.Color.Dtos;
using Application.Features.Color.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Profiles
{
    public class CityMappingProfiles : Profile
    {
       public CityMappingProfiles()
        {
            CreateMap<City, CityDto>().ReverseMap();   
            CreateMap<CreateCityCommand, City>().ReverseMap();
            //CreateMap<DeleteColorCommand, Domain.Entities.Color>().ReverseMap();
            CreateMap<UpdateCityCommand, City>().ReverseMap();
            CreateMap<CityListModel, IPaginate<City>>().ReverseMap();
            CreateMap<City, CityListDto>().ReverseMap();
        }
    }
}
