using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.Jwt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands
{
    public class RegisterUserCommand: IRequest<CreateUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, CreateUserDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly ITokenHelper _tokenHelper;

            public RegisterUserCommandHandler(IMapper mapper, IUserRepository userRepository, UserBusinessRules userBusinessRules, ITokenHelper tokenHelper)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _userBusinessRules = userBusinessRules;
                _tokenHelper = tokenHelper;
            }

            public async Task<CreateUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.EmailCanNotBeDuplicated(request.Email);
                var userToRegister = _mapper.Map<User>(request);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                userToRegister.PasswordHash = passwordHash;
                userToRegister.PasswordSalt = passwordSalt;
                userToRegister.Status = true;
                 
                var createUser = await _userRepository.AddAsync(userToRegister);

                List<OperationClaim> claims = _userRepository.GetClaims(createUser);
                var accessToken = _tokenHelper.CreateToken(createUser, claims);

                var dtoUser = _mapper.Map<CreateUserDto>(createUser);
                dtoUser.AccessToken = accessToken;

                return dtoUser;
            }
        }
    }
}