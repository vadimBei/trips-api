using MediatR;
using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Application.Common.ViewModels;

namespace Trips.Core.Application.Trips.Queries.GetApprovedTrips
{
    public class GetApprovedTripsQueryHandler : IRequestHandler<GetApprovedTripsQuery, PaginatedTripsVM>
    {
        private readonly ITripService _tripService;
        private readonly IMapperService _mapperService;

        public GetApprovedTripsQueryHandler(
            ITripService tripService
            , IMapperService mapperService)
        {
            _tripService = tripService;
            _mapperService = mapperService;
        }

        public async Task<PaginatedTripsVM> Handle(GetApprovedTripsQuery request, CancellationToken cancellationToken)
        {
            var paginatedApprovedTrips = await _tripService
                .GetApprovedTrips(request.Page, request.Limit, cancellationToken);

            var paginatedTrips = _mapperService
                .MapTripsToPaginatedTripsVM(paginatedApprovedTrips);

            return paginatedTrips;
        }
    }
}
