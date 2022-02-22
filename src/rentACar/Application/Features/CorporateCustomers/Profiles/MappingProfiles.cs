using Application.Features.CorporateCustomers.Commands;
using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Models;
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

namespace Application.Features.CorporateCustomers.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<CorporateCustomer, CorporateCustomerDto>().ReverseMap();
            CreateMap<CorporateCustomer, CorporateCustomerListDto>().ReverseMap();
            CreateMap<CorporateCustomer, CreateCorporateCustomerCommand>().ReverseMap();
            CreateMap<User, CreateCorporateCustomerCommand>().ReverseMap();
            CreateMap<CorporateCustomer, DeleteCorporateCustomerCommand>().ReverseMap();
            CreateMap<CorporateCustomer, UpdateCorporateCustomerCommand>().ReverseMap();
            CreateMap<IPaginate<CorporateCustomer>, CorporateCustomerListModel>().ReverseMap();
        }
    }
}
