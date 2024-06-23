using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Application.Exceptions;
using AroundTheWorld.Application.Interfaces.Users;
using AroundTheWorld.Infrastructure.Helpers;
using AutoMapper;


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

            var validateUserData = Validation.validateUserData(
                null,
                editProfileCreds.Email,
                editProfileCreds.BirthDate,
                editProfileCreds.PhoneNumber
                );

            if (validateUserData != string.Empty)
            {
                throw new BadRequestException(validateUserData);
            }

            var user = await _userRepository.GetByIdAsync(userId);
            

            if (user == null)
            {
                throw new NotFoundException("Такого пользователя не существует");
            }

            var userWithThisEmail = await _userRepository.GetByEmailAsync(editProfileCreds.Email);

            if (userWithThisEmail != null && userWithThisEmail.Email != user.Email)
            {
                throw new BadRequestException("Этот email уже занят");
            }

            user.BirthDate = editProfileCreds.BirthDate;
            user.PhoneNumber = editProfileCreds.PhoneNumber;
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
