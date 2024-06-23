using AroundTheWorld.Application.DTO.Days;
using AroundTheWorld.Domain.Entities;
using AutoMapper;

namespace AroundTheWorld.Application.Helpers.AutoMapper
{
    public class TimeIntervalMapper: Profile
    {
        public TimeIntervalMapper()
        {
            CreateMap<CreateTimeSlotDTO, TimeInterval>();
        }
    }
}
