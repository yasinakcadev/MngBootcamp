using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brands.Commands;
using Application.Features.Models.Commands;
using Application.Features.Models.Dtos;
using AutoMapper;
using Domain.Entities;


namespace Application.Features.Brands.Profiles
{
    public class ModelMappingProfiles : Profile
    {
        public ModelMappingProfiles()
        {
            CreateMap<Model, CreateModelCommand>().ReverseMap();
            CreateMap<Model, DeleteModelCommand>().ReverseMap();
            CreateMap<Model, UpdateModelCommand>().ReverseMap();

            CreateMap<Model, ModelDto>().ReverseMap();
            CreateMap<Model, CreateModelDto>().ReverseMap();
        }
    }
}