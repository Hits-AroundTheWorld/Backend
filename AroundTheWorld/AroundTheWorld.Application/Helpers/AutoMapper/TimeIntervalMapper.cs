using AroundTheWorld.Application.DTO.TimeIntervals;
using AroundTheWorld.Domain.Entities;
using AutoMapper;

namespace AroundTheWorld.Application.Helpers.AutoMapper
{
    public class TimeIntervalMapper: Profile
    {
        public TimeIntervalMapper()
        {
            CreateMap<CreateTimeIntervalDTO, TimeInterval>();
        }
    }
}
