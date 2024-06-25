using AroundTheWorld.Application.DTO;
using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Application.Exceptions;
using AroundTheWorld.Application.Interfaces.Users;
using AroundTheWorld.Domain.Entities;
using AroundTheWorld.Infrastructure.Helpers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


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

        public async Task<ProfileInfoDTO> CheckRatingSetPossibility(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var userProfileDTO = _mapper.Map<ProfileInfoDTO>(user);
            return userProfileDTO;
        }
        public async Task SetRating(RatingElement ratingElement)
        {
            var ratedUser = await _userRepository.GetByIdAsync(ratingElement.RatedUserId);
            var GivingRateUserId = await _userRepository.GetByIdAsync(ratingElement.GivingRateUserId);

            if (ratedUser != null)
            {
                throw new NotFoundException("Пользователя для оценки не существует");
            }
            if (GivingRateUserId != null)
            {
                throw new NotFoundException("Оценивающего пользователя не существует");
            }
        }

        private async Task calculateRating()
        {

        }
        
        public async Task<GetUsersDTO> GetAllAusers(GetUsersFilterDTO filters)
        {
            var users = await FilterUsers(filters).ToListAsync();
            var usersDTO = CreateApplicationDTO(users, filters.PageSize, filters.currentPage); 
            return usersDTO;
        }

        private IQueryable<User> FilterUsers(GetUsersFilterDTO filters)
        {
            var user = FilterByName(filters.FullName);
            user = FilterByEmail(user, filters.Email);
            user = FilterByCountry(user, filters.Country);
            user = FilterByAge(user, filters.Age);
            user = FilterByPagination(user, filters.currentPage, filters.PageSize);

            return user;
        }

        private IQueryable<User> FilterByName(string? FullName)
        {
            var users = _userRepository.GetUsersByFullName(FullName);
            return users;
        }
        private IQueryable<User> FilterByEmail(IQueryable<User> users, string? email)
        {
            if (email != null)
            {
                users = users.Where(u => u.Email.Contains(email));
            }

            return users;
        }
        private IQueryable<User> FilterByCountry(IQueryable<User> users, string? country)
        {
            if (country != null)
            {
                users = users.Where(u => u.Country.Contains(country));
            }

            return users;
        }
        private IQueryable<User> FilterByAge(IQueryable<User> users, MinMaxAgeDTO? age)
        {
            if (age != null)
            {
                users = users.Where(u => 
                    CalculateAge(u.BirthDate) < age.MaxAge &&
                    CalculateAge(u.BirthDate) > age.MinAge);
            }

            return users;
        }
        private int CalculateAge(DateTime birthDate)
        {
            var currentDate = DateTime.Now;

            int age = currentDate.Year - birthDate.Year;

            if (currentDate < birthDate.AddYears(age))
            {
                age--;
            }

            return age;
        }

        private IQueryable<User> FilterByPagination(
            IQueryable<User> applications,
            int page,
            int pageSize
            )
        {
            if (page <= 0)
            {
                page = 1;
            }

            var count = applications.Count();

            var countOfPages = (int)Math.Ceiling((double)applications.Count() / pageSize);

            if (countOfPages == 0)
            {
                return applications;
            }

            if (page <= countOfPages)
            {
                var lowerBound = page == 1 ? 0 : (page - 1) * pageSize;
                if (page < countOfPages)
                {
                    applications = applications.Skip(lowerBound).Take(pageSize);
                }
                else
                {
                    applications = applications.Skip(lowerBound).Take(applications.Count() - lowerBound);
                }
                return applications;
            }
            else
            {
                throw new BadRequestException("Такой страницы нет");
            }
        }

        private GetUsersDTO CreateApplicationDTO(
            List<User> users,
            int pageSize,
            int page
            )
        {
            var programsCount = users.Count();

            List<GetUserDTO> usersProfiles = new List<GetUserDTO>();

            foreach (var user in users)
            {
                var userProfile = _mapper.Map<GetUserDTO>(user);

                usersProfiles.Add(userProfile);
            }

            var getUsersDTO = new GetUsersDTO
            {
                Users = usersProfiles,
                Pagination = GetPagination(pageSize, page, programsCount)
            };
            return getUsersDTO;
        }

        private PaginationInfoDTO GetPagination(int size, int page, int elementsCount)
        {
            var pagination = new PaginationInfoDTO
            {
                Page = (int)Math.Ceiling((double)elementsCount / size),
                Current = page,
                Size = size
            };
            return pagination;
        }

    }
}
