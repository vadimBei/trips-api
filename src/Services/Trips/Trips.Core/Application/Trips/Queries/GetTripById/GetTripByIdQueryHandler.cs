using MediatR;
using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Application.Common.ViewModels;

namespace Trips.Core.Application.Trips.Queries.GetTripById
{
    public class GetTripByIdQueryHandler : IRequestHandler<GetTripByIdQuery, TripVM>
    {
        private readonly ITripService _tripService;
        private readonly IMapperService _mapperService;

        public GetTripByIdQueryHandler(
            ITripService tripService
            , IMapperService mapperService)
        {
            _tripService = tripService;
            _mapperService = mapperService;
        }

        public async Task<TripVM> Handle(GetTripByIdQuery request, CancellationToken cancellationToken)
        {
            var trip = await _tripService
                .GetTripById(request.Id, cancellationToken);

            var tripVM = _mapperService.MapTripToVM(trip);
            
            return tripVM;
        }
    }
}
