using MediatR;
using Trips.Core.Application.Common.ViewModels;
using Trips.Core.Domain.Enums;

namespace Trips.Core.Application.Trips.Queries.GetTrips
{
    public class GetTripsQuery : IRequest<PaginatedTripsVM>
    {
        public int Page { get; set; } = 1;

        public int Limit { get; set; } = 100;

        public string LocationObjectId { get; set; }

        public DateTime? DateFrom { get; set; } = null;

        public DateTime? DateTo { get; set; } = null;

        public TripStatus? Status { get; set; } = null;

        public string Search { get; set; } = null;

        public SortFields? SortField { get; set; } = null;

        public SortOrder? SortOrder { get; set; } = null;
    }
}
