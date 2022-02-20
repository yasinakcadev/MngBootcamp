using Application.Features.IndividualCustomer.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomer.Commands
{
    public class CreateIndividualCustomerCommand: IRequest<Domain.Entities.IndividualCustomer>
    {
        public int Id { get; set; }
      //  public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }

        public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, Domain.Entities.IndividualCustomer>
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

            public async Task<Domain.Entities.IndividualCustomer> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                await _individualCustomerBusinessRules.NationalIdCanBotBeDublicated(request.NationalId);


               
                //var userToBeIndividualCustomer = await _userRespository.GetAsync(x => x.Id == request.Id);

                //if (userToBeIndividualCustomer == null)
                //    throw new BusinessException("User cannot found");
                ////var userToBeIndividualCustomer = _mapper.Map<User>(request);

                //byte[] passwordHash, passwordSalt;
                //HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                //userToBeIndividualCustomer.PasswordHash = passwordHash;
                //userToBeIndividualCustomer.PasswordSalt = passwordSalt;
                //userToBeIndividualCustomer.Status = true;
                //_mapper.Map(request, userToBeIndividualCustomer);

                //await _userRespository.UpdateAsync(userToBeIndividualCustomer);

                var mappedIndividualCustomer = _mapper.Map<Domain.Entities.IndividualCustomer>(request);
                var createdIndividualCustomer = await _individualCustomerRepository.AddAsync(mappedIndividualCustomer);
                return createdIndividualCustomer;
            }
        }
    }
}
