using Microsoft.EntityFrameworkCore;
using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Domain.Entities;
using Trips.Core.Domain.Enums;
using Trips.Core.Domain.Models;

namespace Trips.Core.Application.Common.Services
{
    public class SieveService : ISieveService
    {
        public IQueryable<Trip> FilterTrips(TripFilter filter, IQueryable<Trip> entities)
        {
            if (!string.IsNullOrEmpty(filter.LocationObjectId))
            {
                entities = entities
                    .Where(trip => trip.Locations
                                   .Any(location => location.ObjectId == filter.LocationObjectId));
            }

            if (filter.Status != null)
            {
                entities = entities.Where(trip => trip.Status == filter.Status);
            }

            if (filter.DateFrom != null && filter.DateTo != null)
            {
                entities = entities
                    .Where(trip => (trip.DateFrom >= filter.DateFrom && trip.DateTo <= filter.DateTo)
                                || (trip.DateFrom >= filter.DateFrom && trip.DateFrom <= filter.DateTo)
                                || (trip.DateTo >= filter.DateFrom && trip.DateTo <= filter.DateTo));
            }

            if (!string.IsNullOrEmpty(filter.Search))
            {
                entities = entities
                    .Where(trip => EF.Functions.Like(trip.Goal.ToLower(), $"%{filter.Search.ToLower()}%"));
            }

            return entities;
        }

        public List<Trip> SortTrips(List<Trip> trips, TripFilter filter)
        {
            if (filter.SortField != null && filter.SortOrder != null)
            {
                switch (filter.SortField)
                {
                    case SortFields.Locations:
                        {
                            if (filter.SortOrder == SortOrder.ASC)
                                trips = trips.OrderBy(x => x.Locations.First().Location.Name)
                                             .ToList();

                            if (filter.SortOrder == SortOrder.DESC)
                                trips = trips.OrderByDescending(x => x.Locations.First().Location.Name)
                                             .ToList();

                            break;
                        }

                    case SortFields.DateFrom:
                        {
                            if (filter.SortOrder == SortOrder.ASC)
                                trips = trips.OrderBy(x => x.DateFrom)
                                             .ToList();

                            if (filter.SortOrder == SortOrder.DESC)
                                trips = trips.OrderByDescending(x => x.DateFrom)
                                             .ToList();

                            break;
                        }

                    case SortFields.DateTo:
                        {
                            if (filter.SortOrder == SortOrder.ASC)
                                trips = trips.OrderBy(x => x.DateTo)
                                             .ToList();

                            if (filter.SortOrder == SortOrder.DESC)
                                trips = trips.OrderByDescending(x => x.DateTo)
                                             .ToList();

                            break;
                        }

                    case SortFields.ParticipantsNumber:
                        {
                            if (filter.SortOrder == SortOrder.ASC)
                                trips = trips.OrderBy(x => x.Participants.Count)
                                    .ToList();

                            if (filter.SortOrder == SortOrder.DESC)
                                trips = trips.OrderByDescending(x => x.Participants.Count)
                                    .ToList();

                            break;
                        }

                    case SortFields.Author:
                        {
                            if (filter.SortOrder == SortOrder.ASC)
                                trips = trips.OrderBy(x => x.Author.LastName)
                                             .ToList();

                            if (filter.SortOrder == SortOrder.DESC)
                                trips = trips.OrderByDescending(x => x.Author.LastName)
                                             .ToList();

                            break;
                        }

                    case SortFields.Status:
                        {
                            if (filter.SortOrder == SortOrder.ASC)
                                trips = trips.OrderBy(x => x.Status)
                                             .ToList();

                            if (filter.SortOrder == SortOrder.DESC)
                                trips = trips.OrderByDescending(x => x.Status)
                                             .ToList();

                            break;
                        }
                }
            }

            return trips;
        }
    }
}
