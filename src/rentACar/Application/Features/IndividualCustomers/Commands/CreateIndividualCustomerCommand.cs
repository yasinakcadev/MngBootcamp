using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.IndividualCustomers.Commands
{
    public class CreateIndividualCustomerCommand : IRequest<IndividualCustomer>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }

        public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, IndividualCustomer>
        {
            IIndividualCustomerRepository _individualCustomerRepository;
            IMapper _mapper;
            IndividualCustomerBusinessRules _individualCustomerBusinessRules;
            IUserRepository _userRespository;


            public CreateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusinessRules individualCustomerBusinessRules, IUserRepository userRespository)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _individualCustomerBusinessRules = individualCustomerBusinessRules;
                _userRespository = userRespository;
            }

            public async Task<IndividualCustomer> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
             
                var user= await _userRespository.GetAsync(u=>u.Id==request.UserId);
                if (user == null)
                {
                    throw new BusinessException("User can not be found");
                }
                await _individualCustomerBusinessRules.NationalIdCanBotBeDublicated(request.NationalId);
                await _individualCustomerBusinessRules.UserIdCanBotBeDublicated(request.UserId);


                var mappedIndividualCustomer = _mapper.Map<Domain.Entities.IndividualCustomer>(request);
                var createdIndividualCustomer = await _individualCustomerRepository.AddAsync(mappedIndividualCustomer);
                return createdIndividualCustomer;
            }
        }
    }
}
