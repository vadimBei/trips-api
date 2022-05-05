using Trips.Core.Domain.Entities;
using Trips.Core.Domain.Models;

namespace Trips.Core.Application.Common.Interfaces
{
    public interface ISieveService
    {
        IQueryable<Trip> FilterTrips(TripFilter filter, IQueryable<Trip> entities);

        List<Trip> SortTrips(List<Trip> trips, TripFilter filter);
    }
}
