using Algolia.Core.Application.Common.Interfaces;
using Algolia.Core.Domain.Entities;
using Algolia.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Algolia.Core.Application.Common.Services
{
    public class AlgoliaService : IAlgoliaService
    {
        private readonly IAlgoliaRepository _algoliaRepository;
        private readonly IApplicationDbContext _applicationDbContext;

        public AlgoliaService(
            IAlgoliaRepository algoliaRepository
            , IApplicationDbContext applicationDbContext)
        {
            _algoliaRepository = algoliaRepository;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Location> SearchLocationByObjectId(string objectId, CancellationToken cancellationToken)
        {
            var algoliaLocation = await _algoliaRepository.SearchLocationByObjectId(objectId, cancellationToken);

            var name = this.MakeLocationName(algoliaLocation.LocaleNames.Default);

            var location = new Location()
            {
                Administrative = algoliaLocation.Administrative.First(),
                Country = algoliaLocation.Country.Default,
                CountryCode = algoliaLocation.CountryCode,
                County = algoliaLocation.County.Default,
                Latitude = algoliaLocation.Geoloc.Latitude,
                Longitude = algoliaLocation.Geoloc.Longitude,
                ObjectID = algoliaLocation.ObjectID,
                Name = name
            };

            return location;
        }

        private string MakeLocationName(List<string> names)
        {
            var name = string.Empty;

            if (names.Count > 1)
                name = $"{names[0]} ({names[1]})";
            else
                name = names.FirstOrDefault();


            return name;
        }

        public async Task<List<Location>> SearchLocationsByName(string name, CancellationToken cancellationToken)
        {
            var hits = await _algoliaRepository.SearchLocationsByName(name, cancellationToken);

            var locations = this.ConvertHitsToLocations(hits);

            return locations;
        }

        private List<Location> ConvertHitsToLocations(List<Hit> hits)
        {
            var locations = new List<Location>();

            foreach (var hit in hits)
            {
                var name = this.MakeLocationName(hit.LocaleNames);

                var location = new Location()
                {
                    Administrative = hit.Administrative.First(),
                    Country = hit.HighlightResult.Country.Value,
                    CountryCode = hit.CountryCode,
                    County = hit.County,
                    Latitude = hit.Geoloc.Latitude,
                    Longitude = hit.Geoloc.Longitude,
                    ObjectID = hit.ObjectID,
                    Name = name
                };

                locations.Add(location);
            }

            return locations;
        }

        public async Task<Location> GetLocationByObjectId(string objectId, CancellationToken cancellationToken)
        {
            var location = await _applicationDbContext.Locations
                .SingleOrDefaultAsync(location => location.ObjectID == objectId, cancellationToken);

            return location;
        }

        public async Task CreateLocations(IEnumerable<Location> locations, CancellationToken cancellationToken)
        {
            foreach (var location in locations)
            {
                var existLocation = await _applicationDbContext
                    .Locations.SingleOrDefaultAsync(l => l.ObjectID == location.ObjectID, cancellationToken);

                if (existLocation == null)
                {
                    await _applicationDbContext.Locations
                        .AddAsync(location, cancellationToken);

                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                }
            }
        }
    }
}
