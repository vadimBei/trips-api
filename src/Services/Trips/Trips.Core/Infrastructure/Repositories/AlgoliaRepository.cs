using Common.Data.WebClient.Extensions;
using Common.Data.WebClient.Interfaces;
using Trips.Core.Application.Common.Interfaces;
using Trips.Core.Domain.Models;

namespace Trips.Core.Infrastructure.Repositories
{
    public class AlgoliaRepository : IAlgoliaRepository
    {
        private readonly IWebClient _webClient;

        public AlgoliaRepository(
            IWebClient webClient)
        {
            _webClient = webClient;
            _webClient.Configure(x =>
            {
                x.WebResourcePath = "algolia-api/algolia-places-service";
            });
        }

        public async Task<AlgoliaLocation> GetLocationByObjectId(string objectId, CancellationToken cancellationToken)
        {
            var queryParams = new
            {
                objectId = objectId
            };

            var location = await _webClient
                .WithQueryParams(queryParams)
                .Get<AlgoliaLocation>("by-objectId", cancellationToken);

            return location;
        }
    }
}
