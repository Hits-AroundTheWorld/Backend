using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Domain.Entities;
using AutoMapper;

public class TripMapper : Profile
{
    public TripMapper()
    {
        CreateMap<CreateTripInfoDTO, Trip>();
        CreateMap<Trip, TripInfoDTO>();
        CreateMap<ApplyForTripInfoDTO, TripAndUsers>();
        CreateMap<User, GetTripUsersDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.AboutMe, opt => opt.MapFrom(src => src.AboutMe))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        CreateMap<TripAndUsers, RequestsInfoDTO>();
        CreateMap<TripAndUsers, GetMyRequestsDTO>();
        CreateMap<TripAndUsers, GetTripUsersDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User.Id))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.AboutMe, opt => opt.MapFrom(src => src.User.AboutMe))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.User.Country))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.User.BirthDate))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber));
    }
}
