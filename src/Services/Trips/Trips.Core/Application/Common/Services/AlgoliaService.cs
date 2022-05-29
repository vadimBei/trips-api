using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Domain.Models;

namespace Trips.Core.Application.Common.Services
{
    public class AlgoliaService : IAlgoliaService
    {
        private readonly IAlgoliaRepository _algoliaRepository;

        public AlgoliaService(
            IAlgoliaRepository algoliaRepository)
        {
            _algoliaRepository = algoliaRepository;
        }

        public async Task<AlgoliaLocation> GetLocationByObjectId(string objectId, CancellationToken cancellationToken)
        {
            return await _algoliaRepository
                 .GetLocationByObjectId(objectId, cancellationToken);
        }
    }
}
