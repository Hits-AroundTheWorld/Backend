using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Domain.Entities;
using AutoMapper;

namespace AroundTheWorld.Application.Helpers.AutoMapper
{
    public class TripMapper: Profile
    {
        public TripMapper() { 
            CreateMap<CreateTripInfoDTO, Trip>();
            CreateMap<Trip, TripInfoDTO>();
            CreateMap<ApplyForTripInfoDTO, TripAndUsers>();
            CreateMap<User, GetTripUsersDTO>();
            CreateMap<TripAndUsers, RequestsInfoDTO>();
            CreateMap<TripAndUsers, GetMyRequestsDTO>();
        }
    }
}
