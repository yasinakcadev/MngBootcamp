using Application.Features.Color.Commands;
using Application.Features.Color.Dtos;
using Application.Features.Color.Models;
using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Color.Profiles
{
    public class ColorMappingProfiles: Profile
    {
       public ColorMappingProfiles()
        {
            CreateMap<Domain.Entities.Color,ColorDto>().ReverseMap();   
            CreateMap<CreateColorCommand, Domain.Entities.Color>().ReverseMap();
            //CreateMap<DeleteColorCommand, Domain.Entities.Color>().ReverseMap();
            CreateMap<UpdateColorCommand, Domain.Entities.Color>().ReverseMap();
            CreateMap<ColorListModel, IPaginate<Domain.Entities.Color>>().ReverseMap();
            CreateMap<Domain.Entities.Color,ColorListDto>().ReverseMap();
        }
    }
}
