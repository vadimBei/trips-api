using Trips.Core.Domain.Models;

namespace Trips.Core.Application.Common.Interfaces
{
    public interface IAlgoliaService
    {
        Task<AlgoliaLocation> GetLocationByObjectId(string objectId, CancellationToken cancellationToken);
    }
}
