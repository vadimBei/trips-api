using Common.Data.Helpers;
using Trips.Core.Application.Common.Dtos;
using Trips.Core.Domain.Entities;
using Trips.Core.Domain.Enums;
using Trips.Core.Domain.Models;

namespace Trips.Core.Application.Common.Interfaces
{
    public interface ITripStrategy
    {
        Task<Trip> GetTripById(long id, CancellationToken cancellationToken);

        Task<Trip> UpdateTrip(TripToUpdateDto tripDto, TripType tripType, CancellationToken cancellationToken);

        Task<PaginatedList<Trip>> GetTrips(TripFilter filter, CancellationToken cancellationToken);

        Task ChangeTripStatus(long id, TripStatus status, CancellationToken cancellationToken);

        Task DeleteTrip(long tripId, CancellationToken cancellationToken);
    }
}
