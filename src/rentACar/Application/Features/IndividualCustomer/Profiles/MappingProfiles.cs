using Application.Features.IndividualCustomer.Commands;
using Application.Features.IndividualCustomer.Dtos;
using Application.Features.IndividualCustomer.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomer.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.IndividualCustomer, IndividualCustomerDto>().ReverseMap();
            CreateMap<Domain.Entities.IndividualCustomer, IndividualCustomerListDto>().ReverseMap();
            CreateMap<Domain.Entities.IndividualCustomer, CreateIndividualCustomerCommand>().ReverseMap();
            CreateMap<User, CreateIndividualCustomerCommand>().ReverseMap();
            CreateMap<Domain.Entities.IndividualCustomer, DeleteIndividualCustomerCommand>().ReverseMap();
            CreateMap<Domain.Entities.IndividualCustomer, UpdateIndividualCustomerCommand>().ReverseMap();
            CreateMap<IPaginate<Domain.Entities.IndividualCustomer>, IndividualCustomerListModel>().ReverseMap();
        }
    }
}
