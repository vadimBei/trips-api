using Common.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Trips.Core.Application.Common.Dtos;
using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Application.Common.Strategies;
using Trips.Core.Domain.Entities;
using Trips.Core.Domain.Enums;
using Trips.Core.Domain.Models;

namespace Trips.Core.Application.Common.Services
{
    public class TripService : ITripService
    {
        private ITripStrategy TripStrategy { get; set; }

        private readonly ISieveService _sieveService;
        private readonly IMapperService _mapperService;
        private readonly IAlgoliaService _algoliaService;
        private readonly IEmployeeService _employeeService;
        private readonly IApplicationDbContext _applicationDbContext;

        public TripService(
            ISieveService sieveService
            , IMapperService mapperService
            , IAlgoliaService algoliaService
            , IEmployeeService employeeService
            , IApplicationDbContext applicationDbContext)
        {
            _sieveService = sieveService;
            _mapperService = mapperService;
            _algoliaService = algoliaService;
            _employeeService = employeeService;
            _applicationDbContext = applicationDbContext;

            this.TripStrategyInitialization();
        }

        private void TripStrategyInitialization()
        {
            var isCurrentUserAdmin = true;

            if (isCurrentUserAdmin)
                TripStrategy = new AdminTripStrategy(_sieveService, _mapperService, _applicationDbContext);
            else
                TripStrategy = new EmployeeTripStrategy(_sieveService, _mapperService, _applicationDbContext);
        }

        public async Task ChangeTripStatus(long id, TripStatus status, CancellationToken cancellationToken)
        {
            await TripStrategy
                .ChangeTripStatus(id, status, cancellationToken);
        }

        public async Task<Trip> CreateTrip(TripToCreateDto createDto, CancellationToken cancellationToken)
        {
            var employeeIds = createDto.Participants
               .Select(p => p.EmployeeId)
               .Distinct()
               .ToList();

            this.CheckParticipants(employeeIds, createDto.DateFrom, createDto.DateTo);

            var tripType = await this.DetermineTripType(createDto.Locations.Select(c => c.ObjectID), cancellationToken);

            var locations = _mapperService.MapLocationsDtosToEntities(createDto.Locations);

            var participants = _mapperService.MapParticipantsDtosToEntities(createDto.Participants);

            var entity = new Trip()
            {
                DateFrom = createDto.DateFrom,
                DateTo = createDto.DateTo,
                Comment = createDto.Comment,
                Type = tripType,
                Locations = locations,
                Participants = participants,
                Goal = createDto.Goal,
                VehicleType = createDto.VehicleType
            };

            _applicationDbContext.Trips.Add(entity);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        private void CheckParticipants(List<Guid> employeeIds, DateTime dateFrom, DateTime dateTo)
        {
            foreach (var employeeId in employeeIds)
            {
                var trips = _applicationDbContext.Trips
                   .Include(trip => trip.Participants)
                       .ThenInclude(participant => participant.Employee)
                   .Where(trip => trip.Participants.Any(participant => participant.EmployeeId == employeeId));

                var participantBuzy = trips.Any(trip => (dateFrom >= trip.DateFrom && dateTo <= trip.DateFrom)
                                                        && (dateFrom <= trip.DateTo && dateTo >= trip.DateTo));

                if (participantBuzy)
                {
                    //throw new TripsForbiddenException($"{nameof(EmployeeTripStrategy)}. Participant is buzy.", 13);
                }
            }
        }

        private async Task<TripType> DetermineTripType(IEnumerable<string> objectIds, CancellationToken cancellationToken)
        {
            var locations = new List<AlgoliaLocation>();

            foreach (var objectId in objectIds)
            {
                locations.Add(
                    await _algoliaService
                        .GetLocationByObjectId(objectId, cancellationToken));
            }

            var abroadLocation = locations
                .Where(location => location.CountryCode != "ua");

            return abroadLocation.Any()
                ? TripType.Abroad
                : TripType.Local;
        }

        public async Task DeleteTrip(long tripId, CancellationToken cancellationToken)
        {
            await TripStrategy.DeleteTrip(tripId, cancellationToken);
        }

        public async Task<PaginatedList<Trip>> GetApprovedTrips(int page, int limit, CancellationToken cancellationToken)
        {
            var trips = _applicationDbContext.Trips
                .Where(t => t.ApprovedDate != DateTime.MinValue)
                .AsNoTracking();

            var paginatedTrips = await PaginatedList<Trip>.CreateAsync(trips, page, limit);

            paginatedTrips.Items.ForEach(async trip =>
                trip = await this.AssambleTrip(trip, cancellationToken));

            return paginatedTrips;
        }

        private async Task<Trip> AssambleTrip(Trip trip, CancellationToken cancellationToken)
        {
            foreach (var participant in trip.Participants)
            {
                participant.Employee = await _employeeService
                    .GetEmployeeById(participant.EmployeeId, cancellationToken);
            }

            foreach (var location in trip.Locations)
            {
                location.Location = await _algoliaService
                    .GetLocationByObjectId(location.ObjectId, cancellationToken);
            }

            return trip;
        }

        public async Task<Trip> GetTripById(long id, CancellationToken cancellationToken)
        {
            var trip = await TripStrategy.GetTripById(id, cancellationToken);

            trip = await this.AssambleTrip(trip, cancellationToken);

            return trip;
        }

        public async Task<PaginatedList<Trip>> GetTrips(TripFilter filter, CancellationToken cancellationToken)
        {
            var paginatedTrips = await TripStrategy.GetTrips(filter, cancellationToken);

            paginatedTrips.Items.ForEach(async trip =>
                trip = await this.AssambleTrip(trip, cancellationToken));

            return paginatedTrips;
        }

        public async Task<Trip> UpdateTrip(TripToUpdateDto tripDto, CancellationToken cancellationToken)
        {
            var tripType = await this.DetermineTripType(tripDto.Locations.Select(c => c.ObjectID), cancellationToken);

            var updatedTrip = await TripStrategy.UpdateTrip(tripDto, tripType, cancellationToken);

            updatedTrip = await this.AssambleTrip(updatedTrip, cancellationToken);

            return updatedTrip;
        }
    }
}
