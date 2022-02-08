
using Application.Features.Rents.Command;
using AutoMapper;

namespace Application.Features.Rents.Profiles;

public class RentMappingProfiles:Profile
{
    public RentMappingProfiles()
    {
        CreateMap<CreateRentCommand, Domain.Entities.Rent>();
    }
}