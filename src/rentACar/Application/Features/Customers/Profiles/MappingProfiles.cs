using Application.Features.Customers.Dtos;
using Application.Features.Customers.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerListDto>().ReverseMap();
            CreateMap<IPaginate<Customer>, CustomerListModel>().ReverseMap();
        }
    }
}
