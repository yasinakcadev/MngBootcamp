using Application.Features.Transmissions.Commands;
using Application.Features.Transmissions.Dtos;
using Application.Features.Transmissions.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Transmissions.Profiles
{
    public class TransmissionMappingProfiles : Profile
    {
        public TransmissionMappingProfiles()
        {
            CreateMap<Transmission, CreateTransmissionCommand>().ReverseMap();
            CreateMap<Transmission, DeleteTransmissionCommand>().ReverseMap();
            CreateMap<Transmission, UpdateTranmissionCommand>().ReverseMap();
            CreateMap<Transmission, TransmissionDto>().ReverseMap();
            CreateMap<Transmission, TransmissionListDto>().ReverseMap();
            CreateMap<TransmissionListModel, IPaginate<Transmission>>().ReverseMap();
        }
    }
}
