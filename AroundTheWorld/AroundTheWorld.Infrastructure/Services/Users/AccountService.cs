using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Application.Interfaces;
using AroundTheWorld.Application.Interfaces.Users;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Infrastructure.Services.Users
{
    public class AccountService : IAccountService
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;


        public AccountService(
            IMapper mapper,
            IUserRepository userRepository

        )
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task EditProfile(EditProfileDTO editProfileCreds, Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("");
            }

            user.AboutMe = editProfileCreds.AboutMe;
            user.FullName = editProfileCreds.FullName;
            user.Email = editProfileCreds.Email;
            user.Country = editProfileCreds.Country;

            await _userRepository.UpdateAsync(user);
        }

        public async Task<ProfileInfoDTO> GetProfile(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var userProfileDTO = _mapper.Map<ProfileInfoDTO>(user);
            return userProfileDTO;
        }
    }
}
