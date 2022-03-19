using Algolia.Core.Domain.Models;

namespace Algolia.Core.Application.Common.Interfaces
{
    public interface IAlgoliaService
    {
        Task<Location> SearchLocationByObjectId(string objectId, CancellationToken cancellationToken);

        Task<List<Location>> SearchLocationsByName(string name, CancellationToken cancellationToken);
    }
}
