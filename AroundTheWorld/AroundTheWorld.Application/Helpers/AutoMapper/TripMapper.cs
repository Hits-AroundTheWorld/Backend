using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Helpers.AutoMapper
{
    public class TripMapper: Profile
    {
        public TripMapper() { 
            CreateMap<CreateTripInfoDTO, Trip>();
            CreateMap<Trip, GetTripsInfoDTO>();
            CreateMap<ApplyForTripInfoDTO, TripAndUsers>();
        }
    }
}
