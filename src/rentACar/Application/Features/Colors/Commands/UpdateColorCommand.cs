using Application.Features.Colors.Dtos;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Commands
{
    public class UpdateColorCommand : IRequest<ColorDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateColorHandler : IRequestHandler<UpdateColorCommand, ColorDto>
        {
            private IColorRepository _colorRepository;
            private IMapper _mapper;
            private ColorBusinessRules _colorBusinessRules;

            public UpdateColorHandler(IColorRepository colorRepository, IMapper mapper, ColorBusinessRules colorBusinessRules)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
                _colorBusinessRules = colorBusinessRules;
            }

            public async Task<ColorDto> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
            {
                var color = await _colorRepository.GetAsync(c => c.Id == request.Id);
                if (color == null)
                    throw new BusinessException("Color cannot found");
                
                await _colorBusinessRules.ColorNameCanNotNeDuplicatedWhenInsertedAndUpdated(request.Name);
                _mapper.Map(request,color);

                await _colorRepository.UpdateAsync(color);
                return _mapper.Map<ColorDto>(color);
            }
        }
    }
}
