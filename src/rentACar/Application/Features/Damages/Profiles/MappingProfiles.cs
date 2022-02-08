using Application.Features.Damages.Commands;
using Application.Features.Damages.Dtos;
using Application.Features.Damages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Damages.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Damage, CreateDamageCommand>().ReverseMap();
            CreateMap<Damage, DeleteDamageCommand>().ReverseMap();
            CreateMap<Damage, UpdateDamageCommand>().ReverseMap();
            CreateMap<Damage, DamageListDto>().ReverseMap();
            CreateMap<Damage, DamageDto>().ReverseMap();
            CreateMap<IPaginate<Damage>, DamageListModel>().ReverseMap();
        }
    }
}
