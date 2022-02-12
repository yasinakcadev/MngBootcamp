using Application.Features.AdditionalServices.Dtos;
using Application.Features.AdditionalServices.Queries;
using Core.Persistence.Paging;

namespace Application.Features.AdditionalServices.Models;

public class AdditionalServiceModel : BasePageableModel
{
    public IList<AdditionalServiceListDto> Items { get; set; }
}