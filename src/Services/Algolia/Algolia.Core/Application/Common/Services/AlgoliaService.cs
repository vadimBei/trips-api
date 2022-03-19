using Algolia.Core.Application.Common.Interfaces;
using Algolia.Core.Domain.Models;

namespace Algolia.Core.Application.Common.Services
{
    public class AlgoliaService : IAlgoliaService
    {
        private readonly IAlgoliaRepository _algoliaRepository;

        public AlgoliaService(
            IAlgoliaRepository algoliaRepository)
        {
            _algoliaRepository = algoliaRepository;
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
    }
}
