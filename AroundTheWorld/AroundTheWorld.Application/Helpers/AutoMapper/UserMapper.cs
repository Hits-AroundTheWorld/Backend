using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Domain.Entities;
using AutoMapper;

namespace AroundTheWorld.Application.Helpers.AutoMapper
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<User, ProfileInfoDTO>();
            CreateMap<User, GetUserDTO>();
            CreateMap<RegisterInfoDTO, User>();
        }
    }
}
