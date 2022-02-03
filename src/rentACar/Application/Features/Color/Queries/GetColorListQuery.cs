using Application.Features.Color.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Color.Queries
{
    public class GetColorListQuery: IRequest<ColorListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetColorListQueryHandler : IRequestHandler<GetColorListQuery, ColorListModel>
        {
            IColorRepository _colorRepository;
            IMapper _mapper;

            public GetColorListQueryHandler(IColorRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<ColorListModel> Handle(GetColorListQuery request, CancellationToken cancellationToken)
            {
                var colors = await _colorRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                var mappedColor = _mapper.Map<ColorListModel>(colors);
                return mappedColor;
            }
        }
    }
}
