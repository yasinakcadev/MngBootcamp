using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.Jwt;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class LoginUserCommand : IRequest<LoginUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRespository;
            private UserBusinessRules _userBusinessRules;
            private ITokenHelper _tokenHelper;

            public LoginUserCommandHandler(IMapper mapper, IUserRepository userRespository, UserBusinessRules userBusinessRules, ITokenHelper tokenHelper)
            {
                _mapper = mapper;
                _userRespository = userRespository;
                _userBusinessRules = userBusinessRules;
                _tokenHelper = tokenHelper;
            }

            public async Task<LoginUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var userToLogin = await _userRespository.GetAsync(u => u.Email == request.Email);
                if (userToLogin == null)
                    throw new BusinessException("User does not exists");

                var isPasswordVerified = HashingHelper.VerifyPasswordHash(request.Password, userToLogin.PasswordHash, userToLogin.PasswordSalt);
                if (!isPasswordVerified)
                    throw new BusinessException("Password is not valid");

                List<OperationClaim> claims = _userRespository.GetClaims(userToLogin);
                var accessToken = _tokenHelper.CreateToken(userToLogin, claims);

                return new LoginUserDto
                {
                    AccessToken = accessToken
                };
            }
        }
    }
}
