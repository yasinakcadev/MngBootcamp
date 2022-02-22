using Application.Features.IndividualCustomers.Commands;
using Application.Features.IndividualCustomers.Dtos;
using Application.Features.IndividualCustomers.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<IndividualCustomer, IndividualCustomerDto>().ReverseMap();
            CreateMap<IndividualCustomer, IndividualCustomerListDto>().ReverseMap();
            CreateMap<IndividualCustomer, CreateIndividualCustomerCommand>().ReverseMap();
            CreateMap<User, CreateIndividualCustomerCommand>().ReverseMap();
            CreateMap<IndividualCustomer, DeleteIndividualCustomerCommand>().ReverseMap();
            CreateMap<IndividualCustomer, UpdateIndividualCustomerCommand>().ReverseMap();
            CreateMap<IPaginate<IndividualCustomer>, IndividualCustomerListModel>().ReverseMap();
        }
    }
}
