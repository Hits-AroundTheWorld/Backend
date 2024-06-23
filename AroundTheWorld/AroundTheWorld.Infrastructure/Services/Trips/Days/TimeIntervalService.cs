using AroundTheWorld.Application.DTO.Days;
using AroundTheWorld.Application.Exceptions;
using AroundTheWorld.Application.Interfaces.Days;
using AroundTheWorld.Application.Interfaces.Trips;
using AroundTheWorld.Domain.Entities;
using AutoMapper;

namespace AroundTheWorld.Infrastructure.Services.Trips.Days
{
    public class TimeIntervalService : ITimeIntervalService
    {

        private ITimeIntervalRepository _timeIntervalRepository;
        private ITripRepository _tripRepository;

        private IMapper _mapper;
        public TimeIntervalService(IMapper mapper, ITimeIntervalRepository timeIntervalRepository, ITripRepository tripRepository)
        { 
            _mapper = mapper;
            _timeIntervalRepository = timeIntervalRepository;
            _tripRepository = tripRepository;
        }

        public async Task CreateTimeInterval(CreateTimeSlotDTO createDayDTO)
        {
            ValidateDayDate(createDayDTO.StartDay, createDayDTO.EndDay);

            var newDay = _mapper.Map<TimeInterval>(createDayDTO);
            await _timeIntervalRepository.AddAsync(newDay);
        }
          
        public Task EditTimeInterval()
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<TimeInterval>> GetTripTimeIntervals(Guid tripId)
        {
            var isTripExists = await _tripRepository.IsTripExists(tripId);

            if (!isTripExists)
            {
                throw new NotFoundException("Поездки с таким id не существует");
            }

            var intervals = _timeIntervalRepository.GetTimeIntervalsByTripId(tripId);
            return intervals;
        }

        private void ValidateDayDate(DateTime StartTime, DateTime EndTime)
        {
            var notEarlierThanNow = StartTime > DateTime.Now;
            var notTooMuch = (EndTime < DateTime.UtcNow.AddYears(100));
            var endMoreThanStart = EndTime > StartTime;
            if (notEarlierThanNow)
            {
                throw new BadRequestException("Нельзя создать поездку в прошлое :( ");
            }
            if (notTooMuch)
            {
                throw new BadRequestException("Нельзя создать поездку, которая закончится через 100 лет");
            }
            if (endMoreThanStart)
            {
                throw new BadRequestException("Старт поездки не может быть после её конца");
            }
        }
    }
}
