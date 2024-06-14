using AroundTheWorld.Application.DTO.Trip;
using AroundTheWorld.Application.Exceptions;
using AroundTheWorld.Application.Interfaces.Trips;
using AroundTheWorld.Application.Interfaces.Users;
using AroundTheWorld.Domain.Entities;
using AroundTheWorld.Infrastructure.Helpers.TripValidation;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(ValidationTripInfo.ValidateTripDate(createTripCreds.StartDate) != string.Empty)
            {
                throw new BadRequestException($"Дата {createTripCreds.StartDate.Date} не подходит, дата должно быть либо сегодняшней, либо будущая!");
            }
            var newTrip = _mapper.Map<Trip>(createTripCreds);
            newTrip.TripFounderId = userId;
            newTrip.CreatedTime = DateTime.Now;
            await _tripRepository.AddAsync(newTrip);
        }

       private async Task<Boolean> IsFounder(Guid userId)
        {
            var trip = await _tripRepository.GetByUserIdAsync(userId);
            if(trip == null){
                return false;
            }
            return true;
        }
    }
}
