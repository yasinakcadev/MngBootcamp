using Application.Features.Transmissions.Dtos;
using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Commands
{
    public class UpdateTranmissionCommand: IRequest<TransmissionDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTranmissionCommand, TransmissionDto>
        {
            private IMapper _mapper;
            private ITransmissionRepository _transmissionRepository;
            private TransmissionBusinessRules _transmissionBusinessRules;

            public UpdateTransmissionCommandHandler(IMapper mapper, ITransmissionRepository transmissionRepository, TransmissionBusinessRules transmissionBusinessRules)
            {
                _mapper = mapper;
                _transmissionRepository = transmissionRepository;
                _transmissionBusinessRules = transmissionBusinessRules;
            }

            public async Task<TransmissionDto> Handle(UpdateTranmissionCommand request, CancellationToken cancellationToken)
            {
                var transmission = await _transmissionRepository.GetAsync(t => t.Id == request.Id);
                if (transmission == null) throw new BusinessException("Transmission does not exists");
                await _transmissionBusinessRules.TransmissionNameCanNotBeDuplicatedWhenInsertedAndUpdated(request.Name);
                _mapper.Map(request, transmission);
                await _transmissionRepository.UpdateAsync(transmission);
                return _mapper.Map<TransmissionDto>(transmission);
            }
        }
    }
}
