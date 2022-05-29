using Trips.Core.Domain.Models;

namespace Trips.Core.Application.Common.Interfaces
{
    public interface IAlgoliaRepository
    {
        Task<AlgoliaLocation> GetLocationByObjectId(string objectId, CancellationToken cancellationToken);
    }
}
