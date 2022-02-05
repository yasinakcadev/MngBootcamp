using Application.Features.Transmission.Commands;
using Application.Features.Transmission.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmission.Profiles
{
    public class TransmissionMappingProfiles: Profile
    {
        public TransmissionMappingProfiles()
        {
            CreateMap<Domain.Entities.Transmission, TransmissionDto>().ReverseMap();
            CreateMap<CreateTransmissionCommand, Domain.Entities.Transmission>().ReverseMap();
        }
    }
}
