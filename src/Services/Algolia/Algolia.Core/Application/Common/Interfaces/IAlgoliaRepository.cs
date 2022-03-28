using Algolia.Core.Domain.Models;

namespace Algolia.Core.Application.Common.Interfaces
{
    public interface IAlgoliaRepository
    {
        Task<AlgoliaLocation> SearchLocationByObjectId(string objectId, CancellationToken cancellationToken);

        Task<List<Hit>> SearchLocationsByName(string name, CancellationToken cancellationToken);
    }
}
