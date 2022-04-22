using Algolia.Core.Application.Common.Interfaces;
using Algolia.Core.Domain.Models;
using Common.Data.WebClient.Extensions;
using Common.Data.WebClient.Interfaces;

namespace Algolia.Core.Infrastructure.Repositories
{
    public class AlgoliaRepository : IAlgoliaRepository
    {
        private readonly IWebClient _webClient;

        public AlgoliaRepository(
            IWebClient webClient)
        {
            _webClient = webClient;
            _webClient.Configure(c =>
            {
                c.WebResourcePath = "algolia-locations-api/algolia-places";
            });
        }

        public async Task<AlgoliaLocation> SearchLocationByObjectId(string objectId, CancellationToken cancellationToken)
        {
            var algoliaLocation = await _webClient
                .Get<AlgoliaLocation>(objectId, cancellationToken);

            return algoliaLocation;
        }

        public async Task<List<Hit>> SearchLocationsByName(string name, CancellationToken cancellationToken)
        {
            var algoliaResponce = await _webClient
                .WithQueryParams($"?query={name}&type=city&language=ua")
                .Get<AlgoliaResponce>("query", cancellationToken);

            return algoliaResponce.Hits;
        }
    }
}
