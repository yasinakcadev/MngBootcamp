using Application.Features.FindexScores.Commands;
using Application.Features.FindexScores.Dtos;
using Application.Features.FindexScores.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.FindexScore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FindexScores.Profiles
{
    public class FindexScoreMappingProfiles : Profile
    {
       public FindexScoreMappingProfiles()
        {
            CreateMap<FindexScore, FindexScoreDto>().ReverseMap();   
            CreateMap<CreateFindexScoreCommand, FindexScore>().ReverseMap();
            //CreateMap<DeleteColorCommand, Domain.Entities.Color>().ReverseMap();
            CreateMap<UpdateFindexScoreCommand, FindexScore>().ReverseMap();
            CreateMap<FindexScoreListModel, IPaginate<FindexScore>>().ReverseMap();
            CreateMap<FindexScore, FindexScoreListDto>().ReverseMap();
        }
    }
}
