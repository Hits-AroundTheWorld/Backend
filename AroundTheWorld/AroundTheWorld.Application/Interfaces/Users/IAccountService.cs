using AroundTheWorld.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Interfaces.Users
{
    public interface IAccountService
    {
        public Task EditProfile(EditProfileDTO editProfileCreds, Guid userId);
        public Task<ProfileInfoDTO> GetProfile(Guid userId);
        public Task<GetUsersDTO> GetAllAusers(GetUsersFilterDTO filters);
    }
}
