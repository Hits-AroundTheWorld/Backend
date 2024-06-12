using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Application.Exceptions;
using AroundTheWorld.Application.Interfaces;
using AroundTheWorld.Application.Interfaces.Users;
using AroundTheWorld.Domain.Entities;
using AroundTheWorld.Infrastructure.Helpers;
using AutoMapper;
using Microsoft.VisualBasic;
using System.Net.WebSockets;

namespace AroundTheWorld.Infrastructure.Services.Users
{
    internal class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IJwtService _tokenService;
        private readonly IUserRepository _userRepository;


        public AuthService(
            IMapper mapper,
            IJwtService tokenService,
            IUserRepository userRepository
        )
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<TokenResponseDTO> Login(LoginInfoDTO loginCreds)
        {
            var user = await _userRepository.GetByEmailAsync(loginCreds.Email);

            if (user == null)
            {
                throw new NotFoundException("Такого пользователя не существует");
            }

            var isCredsValid = BCrypt.Net.BCrypt.Verify(loginCreds.Password, user.Password);

            if (!isCredsValid)
            {
                throw new BadRequestException("Неправильный логин или пароль");
            }

            var token = _tokenService.CreateJWTToken(user.Id);

            var tokenDTO =  new TokenResponseDTO { Token = token };

            return tokenDTO;

        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<TokenResponseDTO> Register(RegisterInfoDTO registerCreds)
        {
            var validateUserData = Validation.validateUserData(
                registerCreds.Password,
                registerCreds.Email, 
                registerCreds.BirthDate,
                registerCreds.PhoneNumber
                );

            if (validateUserData != string.Empty)
            {
                throw new BadRequestException(validateUserData);
            }

            var user = await _userRepository.GetByEmailAsync(registerCreds.Email);

            if (user != null)
            {
                throw new BadRequestException("Этот email уже занят");
            }


            var newUser = _mapper.Map<User>(registerCreds);
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(registerCreds.Password);

            await _userRepository.AddAsync(newUser);

            var loginCreds = new LoginInfoDTO
            {
                Email = registerCreds.Email,
                Password = registerCreds.Password,
            };

            var tokenDTO = await Login(loginCreds);

            return tokenDTO;
        }
        
    }
}
