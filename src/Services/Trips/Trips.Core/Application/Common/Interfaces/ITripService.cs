using Common.Data.Helpers;
using Trips.Core.Application.Common.Dtos;
using Trips.Core.Domain.Entities;
using Trips.Core.Domain.Enums;
using Trips.Core.Domain.Models;

namespace Trips.Core.Application.Common.Interfaces
{
    public interface ITripService
    {
        Task<Trip> CreateTrip(TripToCreateDto createDto, CancellationToken cancellationToken);

        Task DeleteTrip(long tripId, CancellationToken cancellationToken);

        Task<Trip> GetTripById(long id, CancellationToken cancellationToken);

        Task<Trip> UpdateTrip(TripToUpdateDto tripDto, CancellationToken cancellationToken);

        Task<PaginatedList<Trip>> GetTrips(TripFilter filter, CancellationToken cancellationToken);

        Task<PaginatedList<Trip>> GetApprovedTrips(int page, int limit, CancellationToken cancellationToken);

        Task ChangeTripStatus(long id, TripStatus status, CancellationToken cancellationToken);
    }
}
