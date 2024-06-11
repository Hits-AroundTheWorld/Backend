using AroundTheWorld.Application.DTO.User;
using AroundTheWorld.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Helpers.AutoMapper
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<ProfileInfoDTO, User>();
            CreateMap<User, RegisterInfoDTO>();
        }
    }
}
