using Application.Features.AdditionalServices.Commands;
using Application.Features.AdditionalServices.Dtos;
using Application.Features.AdditionalServices.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.AdditionalServices.Profiles;

public class AdditionalServicesMappingProfiles : Profile
{

    public AdditionalServicesMappingProfiles()
    {
        CreateMap<CreateAdditionalServiceCommand, AdditionalService>().ReverseMap();
        CreateMap<UpdateAdditionalServiceCommand, AdditionalService>().ReverseMap();

        CreateMap<AdditionalService, AdditionalServiceListDto>().ReverseMap();
        CreateMap<AdditionalServiceModel, IPaginate<AdditionalService>>().ReverseMap();
    }
}