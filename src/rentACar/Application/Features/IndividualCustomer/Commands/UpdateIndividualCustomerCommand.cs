using Application.Features.IndividualCustomer.Dtos;
using Application.Features.IndividualCustomer.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomer.Commands
{
    public class UpdateIndividualCustomerCommand: IRequest<IndividualCustomerDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand,IndividualCustomerDto>
        {
            IIndividualCustomerRepository _individualCustomerRepository;
            IMapper _mapper;
            IndividualCustomerBusinessRules _individualCustomerBusinessRules;

            public UpdateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusinessRules individualCustomerBusinessRules)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _individualCustomerBusinessRules = individualCustomerBusinessRules;
            }

            public async Task<IndividualCustomerDto> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var individualCustomer = await _individualCustomerRepository.GetAsync(i => i.Id == request.Id);
                if (individualCustomer == null) throw new BusinessException("Individual customer cannot found");
                await _individualCustomerBusinessRules.NationalIdCanBotBeDublicated(request.NationalId);
                _mapper.Map(request, individualCustomer);
                await _individualCustomerRepository.UpdateAsync(individualCustomer);
                var dto = _mapper.Map<IndividualCustomerDto>(individualCustomer);
                return dto;

                //var individualCustomerToUpdate = await _individualCustomerRepository.GetAsync(c => c.Id == request.Id);
                //if (individualCustomerToUpdate == null)
                //{
                //    throw new BusinessException("Customer cannot be found");
                //}
                //await _individualCustomerBusinessRules.NationalIdCanNotBeDuplicatedWhenInserted(request.NationalId);

                //_mapper.Map(request, individualCustomerToUpdate);
                //_individualCustomerRepository.UpdateAsync(individualCustomerToUpdate);
                //var mapped = _mapper.Map<IndividualCustomerDto>(individualCustomerToUpdate);
                //return mapped;
            }
        }
    }
}
