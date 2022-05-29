using Common.Data.Helpers;
using MediatR;
using Trips.Core.Application.Common.ViewModels;

namespace Trips.Core.Application.Trips.Queries.GetApprovedTrips
{
    public class GetApprovedTripsQuery : IRequest<PaginatedTripsVM>
    {
        public int Page { get; set; } = 1;

        public int Limit { get; set; } = 10;
    }
}
