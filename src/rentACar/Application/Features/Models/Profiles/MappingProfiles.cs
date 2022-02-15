using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Models.Commands;
using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;


namespace Application.Features.Models.Profiles
{
    public class ModelMappingProfiles : Profile
    {
        public ModelMappingProfiles()
        {
            CreateMap<Model, CreateModelCommand>().ReverseMap();
            CreateMap<Model, UpdateModelCommand>().ReverseMap();
            CreateMap<Model, ModelDto>().ReverseMap();

            CreateMap<Model, ModelListDto>().ReverseMap();
            CreateMap<ModelListModel, IPaginate<Model>>().ReverseMap();
            //  CreateMap<BrandListModel, IPaginate<Brand>>().ReverseMap();
        }
    }
}