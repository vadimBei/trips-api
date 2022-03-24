using Algolia.Core.Domain.Entities;

namespace Algolia.Core.Application.Common.Interfaces
{
    public interface IAlgoliaService
    {
        Task CreateLocations (IEnumerable<Location> locations, CancellationToken cancellationToken);

        Task<Location> GetLocationByObjectId(string objectId, CancellationToken cancellationToken);

        Task<Location> SearchLocationByObjectId(string objectId, CancellationToken cancellationToken);

        Task<List<Location>> SearchLocationsByName(string name, CancellationToken cancellationToken);
    }
}
