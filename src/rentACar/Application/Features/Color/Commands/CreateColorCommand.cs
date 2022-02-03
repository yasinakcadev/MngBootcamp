using Application.Features.Color.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Color.Commands
{
    public class CreateColorCommand : IRequest<Domain.Entities.Color>
    {
        public string Name { get; set; }

        public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, Domain.Entities.Color>
        {
            private IColorRepository _colorRepository;
            private IMapper _mapper;
            private ColorBusinessRules _colorBusinessRules;

            public CreateColorCommandHandler(IColorRepository colorRepository, IMapper mapper, ColorBusinessRules colorBusiness)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
                _colorBusinessRules = colorBusiness;
            }

            public async Task<Domain.Entities.Color> Handle(CreateColorCommand request, CancellationToken cancellationToken)
            {
                await _colorBusinessRules.ColorNameCanNotNeDuplicatedWhenInsertedAndUpdated(request.Name);
                var mappedColor = _mapper.Map<Domain.Entities.Color>(request);
                var color =  await _colorRepository.AddAsync(mappedColor);
                return color;
            }
        }
    }
}
