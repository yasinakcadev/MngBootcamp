using Application.Features.Users.Commands;
using Application.Features.Users.Dtos;
using AutoMapper;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class UserMappingProfiles: Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
        }
    }
}
