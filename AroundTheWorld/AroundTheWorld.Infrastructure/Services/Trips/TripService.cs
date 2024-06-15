﻿using AroundTheWorld.Application.DTO;
using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Application.Exceptions;
using AroundTheWorld.Application.Interfaces.Trips;
using AroundTheWorld.Application.Interfaces.Users;
using AroundTheWorld.Domain.Entities;
using AroundTheWorld.Domain.Entities.Enums;
using AroundTheWorld.Infrastructure.Helpers.TripValidation;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AroundTheWorld.Infrastructure.Services.Trips
{
    public class TripService : ITripService
    {
        private readonly IMapper _mapper;
        private readonly ITripRepository _tripRepository;
        private readonly IUserRepository _userRepository;
        public TripService(IMapper mapper, ITripRepository tripRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _tripRepository = tripRepository;
            _userRepository = userRepository;
        }
        public async Task CreateTrip(Guid userId, CreateTripInfoDTO createTripCreds)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException("Такого пользователя не существует");
            }
            var errorHandler = ValidationTripInfo.ValidateTripDate(createTripCreds.StartDate, createTripCreds.EndDate);
            if ( errorHandler != string.Empty)
            {
                throw new BadRequestException($"{errorHandler}");
            }
            var newTrip = _mapper.Map<Trip>(createTripCreds);
            newTrip.TripFounderId = userId;
            newTrip.TripFounderFullName = user.FullName;
            newTrip.CreatedTime = DateTime.UtcNow;
            newTrip.PeopleCountNow = 1;
            newTrip.Status = TripStatus.WaitingForStart;
            await _tripRepository.AddAsync(newTrip);
        }
        private IQueryable<Trip> FilterTrips(RequestSorting? sorting, IQueryable<Trip> trips)
        {
            switch (sorting)
            {
                case RequestSorting.CreateAsc:
                    return trips.OrderBy(p => p.StartDate);
                default:
                    return trips.OrderByDescending(p => p.EndDate);
            }

        }
        public async Task<GetQuerybleTripsInfoDTO> GetMyTrips(int size, int page, Guid userId, string? tripName, RequestSorting? requestSorting, DateTime? tripDate)
        {
            if (page <= 0)
            {
                page = 1;
            }
            if (size <= 0)
            {
                size = 10;
            }
            var applications = await _tripRepository.GetByUserIdAsync(userId);
            if (applications == null)
            {
                throw new NotFoundException("У вас нет созданных поездок!");
            }

            var applicationsQueryable = applications.AsQueryable();

            if (tripName != null)
            {
                applicationsQueryable = applicationsQueryable.Where(aR => aR.TripName.Contains(tripName));
            }
            if (tripDate != null)
            {
                applicationsQueryable = applicationsQueryable.Where(aR => aR.StartDate == tripDate);
            }
            applicationsQueryable = FilterTrips(requestSorting, applicationsQueryable);

            int sizeOfPage = size;
            var countOfPages = (int)Math.Ceiling((double)applicationsQueryable.Count() / sizeOfPage);

            if (page > countOfPages)
            {
                throw new BadRequestException("Такой страницы нет");
            }

            var lowerBound = (page - 1) * sizeOfPage;
            var pagedApplications = applicationsQueryable.Skip(lowerBound).Take(sizeOfPage).ToList();

            var paginationDto = new PaginationInfoDTO
            {
                Size = size,
                Page = page,
                Current = countOfPages,
            };

            var tripsDto = _mapper.Map<IEnumerable<GetTripsInfoDTO>>(pagedApplications).AsQueryable();

            var applicationsDTO = new GetQuerybleTripsInfoDTO
            {
                Trips = tripsDto,
                Pagination = paginationDto
            };

            return applicationsDTO;
        }


        public async Task<GetQuerybleTripsInfoDTO> GetPublicTrips(int size, int page, Guid? userId, string? tripName, RequestSorting? requestSorting, DateTime? tripDate)
        {
            if (page <= 0)
            {
                page = 1;
            }
            if (size <= 0)
            {
                size = 10;
            }
            var applications = await _tripRepository.GetTripsAsync();
            if (applications == null)
            {
                throw new NotFoundException("У вас нет созданных поездок!");
            }

            var applicationsQueryable = applications.AsQueryable();
            if(userId != null)
            {
                applicationsQueryable = applicationsQueryable.Where(aR => aR.TripFounderId == userId);
            }
            if (tripName != null)
            {
                applicationsQueryable = applicationsQueryable.Where(aR => aR.TripName.Contains(tripName));
            }
            if (tripDate != null)
            {
                applicationsQueryable = applicationsQueryable.Where(aR => aR.StartDate == tripDate);
            }
            applicationsQueryable = FilterTrips(requestSorting, applicationsQueryable);

            int sizeOfPage = size;
            var countOfPages = (int)Math.Ceiling((double)applicationsQueryable.Count() / sizeOfPage);

            if (page > countOfPages)
            {
                throw new BadRequestException("Такой страницы нет");
            }

            var lowerBound = (page - 1) * sizeOfPage;
            var pagedApplications = applicationsQueryable.Skip(lowerBound).Take(sizeOfPage).ToList();

            var paginationDto = new PaginationInfoDTO
            {
                Size = size,
                Page = page,
                Current = countOfPages,
            };

            var tripsDto = _mapper.Map<IEnumerable<GetTripsInfoDTO>>(pagedApplications).AsQueryable();

            var applicationsDTO = new GetQuerybleTripsInfoDTO
            {
                Trips = tripsDto,
                Pagination = paginationDto
            };

            return applicationsDTO;
        }
    }
}
