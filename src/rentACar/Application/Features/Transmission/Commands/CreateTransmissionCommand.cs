using Application.Features.Transmission.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmission.Commands
{
    public class CreateTransmissionCommand: IRequest<Domain.Entities.Transmission>
    {
        public string Name { get; set; }

        public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, Domain.Entities.Transmission>
        {
            private IMapper _mapper;
            private ITransmissionRepository _transmissionRepository;
            private TransmissionBusinessRules _tranmissionBusinessRules;

            public CreateTransmissionCommandHandler(IMapper mapper, ITransmissionRepository transmissionRepository, TransmissionBusinessRules tranmissionBusinessRules)
            {
                _mapper = mapper;
                _transmissionRepository = transmissionRepository;
                _tranmissionBusinessRules = tranmissionBusinessRules;
            }

            public async Task<Domain.Entities.Transmission> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
            {
                await _tranmissionBusinessRules.TransmissionNameCanNotBeDuplicatedWhenInsertedAndUpdated(request.Name);
                var mappedTransmission = _mapper.Map<Domain.Entities.Transmission>(request);    
                var createdTransmission = await _transmissionRepository.AddAsync(mappedTransmission);
                return createdTransmission;
            }
        }
    }
}
