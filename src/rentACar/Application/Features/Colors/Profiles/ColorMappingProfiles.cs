using Application.Features.Colors.Commands;
using Application.Features.Colors.Dtos;
using Application.Features.Colors.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Profiles
{
    public class ColorMappingProfiles: Profile
    {
       public ColorMappingProfiles()
        {
            CreateMap<Color,ColorDto>().ReverseMap();   
            CreateMap<CreateColorCommand, Color>().ReverseMap();
            //CreateMap<DeleteColorCommand, Domain.Entities.Color>().ReverseMap();
            CreateMap<UpdateColorCommand, Color>().ReverseMap();
            CreateMap<ColorListModel, IPaginate<Color>>().ReverseMap();
            CreateMap<Color,ColorListDto>().ReverseMap();
        }
    }
}
