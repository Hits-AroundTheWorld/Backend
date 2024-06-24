using AroundTheWorld.Application.DTO.TimeIntervals;
using AroundTheWorld.Application.Exceptions;
using AroundTheWorld.Application.Interfaces.Days;
using AroundTheWorld.Application.Interfaces.TimeIntervals;
using AroundTheWorld.Application.Interfaces.Trips;
using AroundTheWorld.Domain.Entities;
using AutoMapper;

namespace AroundTheWorld.Infrastructure.Services.Trips.TimeIntervals
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

        public async Task CreateTimeInterval(CreateTimeIntervalDTO createDayDTO)
        {
            ValidateDayDate(createDayDTO.StartDay, createDayDTO.EndDay, createDayDTO.TripId);

            var newDay = _mapper.Map<TimeInterval>(createDayDTO);
            await _timeIntervalRepository.AddAsync(newDay);
        }
          
        public async Task EditTimeInterval(EditTimeIntervalDTO editTimeIntervalDTO)
        {
            var timeInterval = await _timeIntervalRepository.GetByIdAsync(editTimeIntervalDTO.TimeIntervalId);
            if (timeInterval == null)
            {
                throw new NotFoundException("Временного интервала с таким id нет");
            }

            timeInterval.Title = editTimeIntervalDTO.Title;
            timeInterval.Text = editTimeIntervalDTO.Text;
            timeInterval.IntervalStart = editTimeIntervalDTO.StartDay;
            timeInterval.IntervalEnd = editTimeIntervalDTO.EndDay;
            
            await _timeIntervalRepository.UpdateAsync(timeInterval);
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
        public async Task<GetTimeIntervalDTO> GetTripTimeInterval(Guid TimeIntervalId)
        {

            var interval = await _timeIntervalRepository.GetByIdAsync(TimeIntervalId);

            if (interval == null)
            {
                throw new NotFoundException("Временного интервала с таким id не существует");
            }

            var mapPoints = await _timeIntervalRepository.GetMapPointsByIntervalIdAsync(TimeIntervalId);

            var timeIntervalDTO = new GetTimeIntervalDTO
            {
                MapPoints = mapPoints,
                TimeInterval = interval
            };

            return timeIntervalDTO;
        }

        public async Task EditPointsOnMap(NewMapPointsDTO newMapPointsInfo)
        {
            var timeIntervalExists = await _timeIntervalRepository.IsTimeIntervalExistsAsync(newMapPointsInfo.TimeIntervalId);
            if (!timeIntervalExists)
            {
                throw new NotFoundException("Временной интервал с таким id не существует");
            }
            await _timeIntervalRepository.ClearAllMapPointsAsync(newMapPointsInfo.TimeIntervalId);
            await _timeIntervalRepository.AddMapPointsAsync(newMapPointsInfo.MapPoints, newMapPointsInfo.TimeIntervalId);
        }

        private void ValidateDayDate(DateTime StartTime, DateTime EndTime, Guid tripId) //ПРОВАЛИДИРУЙ, ЧТОБЫ ЕСЛИ У ПОЕЗДКИ ЕСТЬ НАЧАЛО И КОНЕЦ, ТО ДНИ ТОЖЕ ДОЛЖНЫ БЫТЬ В ЭТИХ РАМКАХ
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
