using Application.Features.Damages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Damages.Queries
{
    public class GetDamageListQuery: IRequest<DamageListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetDamageListQueryHandler : IRequestHandler<GetDamageListQuery, DamageListModel>
        {
            IDamageRepository _damageRepository;
            IMapper _mapper;

            public GetDamageListQueryHandler(IDamageRepository damageRepository, IMapper mapper)
            {
                _damageRepository = damageRepository;
                _mapper = mapper;
            }

            public async Task<DamageListModel> Handle(GetDamageListQuery request, CancellationToken cancellationToken)
            {
                var damages = await _damageRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var mappedDamages = _mapper.Map<DamageListModel>(damages);
                return mappedDamages;
            }
        }
    }
}
