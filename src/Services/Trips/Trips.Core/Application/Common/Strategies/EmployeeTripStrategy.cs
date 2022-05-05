using Common.Data.Exceptions;
using Common.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Trips.Core.Application.Common.Dtos;
using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Domain.Entities;
using Trips.Core.Domain.Enums;
using Trips.Core.Domain.Models;

namespace Trips.Core.Application.Common.Strategies
{
    public class EmployeeTripStrategy : ITripStrategy
    {
        private readonly Employee currentEmployee;

        private readonly ISieveService _sieveService;
        private readonly IMapperService _mapperService;
        private readonly IApplicationDbContext _applicationDbContext;

        public EmployeeTripStrategy(
            Employee currentEmployee
            , ISieveService sieveService
            , IMapperService mapperService
            , IApplicationDbContext applicationDbContext)
        {
            this.currentEmployee = currentEmployee;

            _mapperService = mapperService;
            _sieveService = sieveService;
            _applicationDbContext = applicationDbContext;
        }

        public Task ChangeTripStatus(long id, TripStatus status, CancellationToken cancellationToken)
        {
            throw new NotFoundException(nameof(Trip), id);
        }

        public async Task DeleteTrip(long tripId, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Trips
              .SingleOrDefaultAsync(trip => trip.Id == tripId 
                                        && trip.AuthorId == currentEmployee.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Trip), tripId);

            _applicationDbContext.Trips.Remove(entity);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Trip> GetTripById(long id, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Trips
                .Include(trip => trip.Participants)
                .Include(trip => trip.Locations)
                .AsNoTracking()
                .SingleOrDefaultAsync(t => t.AuthorId == currentEmployee.Id
                                    || t.Participants.Any(p => p.EmployeeId == currentEmployee.Id)
                                    , cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Trip), id);

            return entity;
        }

        public async Task<PaginatedList<Trip>> GetTrips(TripFilter filter, CancellationToken cancellationToken)
        {
            var entities = _applicationDbContext.Trips
                 .Include(trip => trip.Participants)
                 .Include(trip => trip.Locations)
                 .Where(t => t.AuthorId == currentEmployee.Id
                          || t.Participants.Any(p => p.EmployeeId == currentEmployee.Id))
                 .AsNoTracking();

            var filteredTrips = _sieveService.FilterTrips(filter, entities);

            return await PaginatedList<Trip>.CreateAsync(filteredTrips, filter.Page, filter.Limit);
        }

        public async Task<Trip> UpdateTrip(TripToUpdateDto tripDto, TripType tripType, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Trips
                .Include(trip => trip.Participants)
                .Include(trip => trip.Locations)
                .SingleOrDefaultAsync(t => t.Id == tripDto.Id
                                        && (t.AuthorId == currentEmployee.Id
                                            || t.Participants.Any(p => p.EmployeeId == currentEmployee.Id))
                         , cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Trip), tripDto.Id);

            var locations = _mapperService.MapLocationsDtosToEntities(tripDto.Locations);

            var participants = _mapperService.MapParticipantsDtosToEntities(tripDto.Participants);

            entity.DateFrom = tripDto.DateFrom;
            entity.DateTo = tripDto.DateTo;
            entity.Comment = tripDto.Comment;
            entity.Goal = tripDto.Goal;
            entity.Type = tripType;
            entity.VehicleType = tripDto.VehicleType;
            entity.Participants = new List<TripParticipant>(participants);
            entity.Locations = new List<TripLocation>(locations);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
