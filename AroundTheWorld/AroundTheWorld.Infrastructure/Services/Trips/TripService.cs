using AroundTheWorld.Application.DTO;
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
using Microsoft.VisualBasic;
using Pipelines.Sockets.Unofficial.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        private readonly ITripAndUsersRepository _tripAndUsersRepository;
        public TripService(IMapper mapper, ITripRepository tripRepository, IUserRepository userRepository, ITripAndUsersRepository tripAndUsersRepository)
        {
            _mapper = mapper;
            _tripRepository = tripRepository;
            _userRepository = userRepository;
            _tripAndUsersRepository = tripAndUsersRepository;
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
        public async Task EditTrip(Guid userId,Guid tripId, EditTripInfoDTO editTripCreds)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException("Такого пользователя не существует");
            }
            var trip= await _tripRepository.GetTripById(userId, tripId); 
            if (trip == null)
            {
                throw new BadRequestException("Вы не можете менять информацию не своей поездки");
            }
            if (editTripCreds.StartDate != null) 
            {
                var errorHandler = ValidationTripInfo.ValidateTripDate(editTripCreds.StartDate, trip.EndDate);
                if (errorHandler != string.Empty)
                {
                    throw new BadRequestException($"{errorHandler}");
                }
                trip.StartDate = editTripCreds.StartDate;
                await _tripRepository.SaveChangeAsync();
            }
            if (editTripCreds.EndDate != null)
            {
                var errorHandler = ValidationTripInfo.ValidateTripDate(trip.StartDate, editTripCreds.EndDate);
                if (errorHandler != string.Empty)
                {
                    throw new BadRequestException($"{errorHandler}");
                }
                trip.EndDate = editTripCreds.EndDate;
                await _tripRepository.SaveChangeAsync();
            }
            if (editTripCreds.TripMiniDescription != null)
            {
                trip.TripMiniDescription = editTripCreds.TripMiniDescription;
            }
            if(editTripCreds.IsPublic != null)
            {
                trip.IsPublic = editTripCreds.IsPublic;
            }
            if(editTripCreds.TripName != null)
            {
                trip.TripName  = editTripCreds.TripName;    
            }
            if(editTripCreds.MaxPeopleCount != null)
            {
                if(editTripCreds.MaxPeopleCount < trip.PeopleCountNow)
                {
                    throw new BadRequestException("Вы не можете указать максимальное количество людей меньше, чем их сейчас!");
                }
                trip.MaxPeopleCount = editTripCreds.MaxPeopleCount;
            }
            await _tripRepository.UpdateAsync(trip);
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
        public async  Task ApplyForTrip(Guid tripId, Guid userId)
        {
            bool isFounder = await _tripRepository.IsFounder(userId, tripId);
            if(isFounder == true)
            {
                throw new BadRequestException("Вы не можете подавать заявки на свою же поездку!");
            }
            var request = await _tripAndUsersRepository.GetRequestByIdAsync(tripId, userId);
            if(request != null)
            {
                throw new BadRequestException("Вы не можете подать несколько раз на одну поездку!");
            }
            var creds = new ApplyForTripInfoDTO
            {
                TripId = tripId,
                UserId = userId
            };
            var newRequest = _mapper.Map<TripAndUsers>(creds);
            newRequest.Status = UserRequestStatus.InQueue;
            await _tripAndUsersRepository.AddAsync(newRequest);
        }

        public async Task ChangeTripRequestStatus(Guid ownerId ,ChangeRequestStatusInfoDTO infoDTO)
        {
            bool isFounder = await _tripRepository.IsFounder(ownerId, infoDTO.TripId);
            if (!isFounder)
            {
                throw new BadRequestException("Вы не можете изменять статус не в вашей заявке!");
            }
            var tripRequest = await _tripAndUsersRepository.GetRequestByIdAsync(infoDTO.UserId, infoDTO.TripId);
            if (tripRequest == null)
            {
                throw new NotFoundException("Запрос на поездку не найден.");
            }
            tripRequest.Status = infoDTO.Status;
            await _tripAndUsersRepository.UpdateAsync(tripRequest);
        }

        public async Task ChangeTripStatus(Guid userId, ChangeTripStatusInfoDTO infoDTO)
        {
            var trip = await _tripRepository.GetTripById(userId, infoDTO.TripId);
            if (trip == null)
            {
                throw new NotFoundException("У вас нет такой поездки, вы не можете менять ей статус!");
            }
            trip.Status = infoDTO.TripStatus;
            await _tripRepository.UpdateAsync(trip);
            if(infoDTO.TripStatus == TripStatus.InProccess)
            {
                var allTrips = await _tripRepository.GetTripsAsync();
                if(allTrips == null)
                {
                    throw new BadRequestException("На данный момент не существует в пуле поездок)");
                }
                var relatedTimeTrips =  allTrips.Where(aT => aT.StartDate >= trip.StartDate && aT.EndDate <= trip.EndDate && aT.TripId != trip.TripId);
                foreach(var relTrip in relatedTimeTrips) {
                    var usersTrip = await _tripAndUsersRepository.GetTripById(relTrip.TripId);
                    usersTrip.Status = UserRequestStatus.Rejected;
                    await _tripAndUsersRepository.UpdateAsync(usersTrip);
                }
            }
        }

        public async Task LeaveFromTrip(Guid userId, Guid tripId)
        {
            var trip = await _tripAndUsersRepository.GetRequestByIdAsync(userId, tripId);
            if(trip == null)
            {
                throw new NotFoundException("Такой поездки не существует!");
            }
            trip.Status = UserRequestStatus.LeftFromTrip;
            await _tripAndUsersRepository.UpdateAsync(trip);
        }

        public async Task<IQueryable<GetUsersFromTripInfoDTO>> GetUsersFromTrip(Guid tripId)
        {
            var users = await _tripAndUsersRepository.GetUsersFromTrip(tripId);

            if (users == null || users.Count == 0)
            {
                return Enumerable.Empty<GetUsersFromTripInfoDTO>().AsQueryable();
            }

            var usersDto = _mapper.ProjectTo<GetUsersFromTripInfoDTO>(users.AsQueryable());

            return usersDto;
        }
        public async Task<GetTripRequestsInfoDTO> GetTripRequests(int size, int page, Guid tripId)
        {
            if (page <= 0)
            {
                page = 1;
            }
            if (size <= 0)
            {
                size = 10;
            }
            var trips = await _tripAndUsersRepository.GetRequests(tripId);
            if (trips == null)
            {
                throw new NotFoundException("У вас нет созданных поездок!");
            }

            var requests = trips.AsQueryable();

            int sizeOfPage = size;
            var countOfPages = (int)Math.Ceiling((double)requests.Count() / sizeOfPage);

            if (page > countOfPages)
            {
                throw new BadRequestException("Такой страницы нет");
            }

            var lowerBound = (page - 1) * sizeOfPage;
            var pagedTrips = requests.Skip(lowerBound).Take(sizeOfPage).ToList();

            var paginationDto = new PaginationInfoDTO
            {
                Size = size,
                Page = page,
                Current = countOfPages,
            };

            var tripsDTO = _mapper.Map<IEnumerable<RequestsInfoDTO>>(pagedTrips).AsQueryable();

            var requestsDTO = new GetTripRequestsInfoDTO
            {
                Requests = tripsDTO,
                PaginationInfo = paginationDto
            };

            return requestsDTO;
        }
    }
}
