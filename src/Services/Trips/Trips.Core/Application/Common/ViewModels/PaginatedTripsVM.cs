using AutoMapper;
using Common.Data.Helpers;
using Trips.Core.Domain.Entities;

namespace Trips.Core.Application.Common.ViewModels
{
    [AutoMap(typeof(PaginatedList<Trip>))]
    public class PaginatedTripsVM
    {
        public int PageIndex { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public List<TripVM> Items { get; set; }
    }
}
