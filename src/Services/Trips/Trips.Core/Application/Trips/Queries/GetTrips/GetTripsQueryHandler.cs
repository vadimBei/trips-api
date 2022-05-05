using MediatR;
using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Application.Common.ViewModels;
using Trips.Core.Domain.Models;

namespace Trips.Core.Application.Trips.Queries.GetTrips
{
    public class GetTripsQueryHandler : IRequestHandler<GetTripsQuery, PaginatedTripsVM>
    {
        private readonly ITripService _tripService;
        private readonly IMapperService _mapperService;

        public GetTripsQueryHandler(
            ITripService tripService
            , IMapperService mapperService)
        {
            _tripService = tripService;
            _mapperService = mapperService;
        }

        public async Task<PaginatedTripsVM> Handle(GetTripsQuery request, CancellationToken cancellationToken)
        {
            var filter = new TripFilter()
            {
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
                Limit = request.Limit,
                Page = request.Page,
                LocationObjectId = request.LocationObjectId,
                Search = request.Search,
                SortField = request.SortField,
                SortOrder = request.SortOrder,
                Status = request.Status
            };

            var trips = await _tripService
                .GetTrips(filter, cancellationToken);

            var tripsVM = _mapperService.MapTripsToPaginatedTripsVM(trips);

            return tripsVM;
        }
    }
}
