
using Application.Features.IndividualCustomers.Dtos;
using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Commands
{
    public class UpdateIndividualCustomerCommand: IRequest<IndividualCustomerDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand,IndividualCustomerDto>
        {
            IIndividualCustomerRepository _individualCustomerRepository;
            IMapper _mapper;
            IndividualCustomerBusinessRules _individualCustomerBusinessRules;
            IUserRepository _userRespository;

            public UpdateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusinessRules individualCustomerBusinessRules, IUserRepository userRespository)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _individualCustomerBusinessRules = individualCustomerBusinessRules;
                _userRespository = userRespository;
            }

            public async Task<IndividualCustomerDto> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var individualCustomer = await _individualCustomerRepository.GetAsync(i => i.Id == request.Id);
                if (individualCustomer == null) throw new BusinessException("Individual customer cannot found");
                var user = await _userRespository.GetAsync(u => u.Id == request.UserId);
                if (user == null)
                {
                    throw new BusinessException("User can not be found");
                }
                await _individualCustomerBusinessRules.NationalIdCanBotBeDublicated(request.NationalId);
                _mapper.Map(request, individualCustomer);
                await _individualCustomerRepository.UpdateAsync(individualCustomer);
                var dto = _mapper.Map<IndividualCustomerDto>(individualCustomer);
                return dto;

           
            }
        }
    }
}
