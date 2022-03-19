using Algolia.Core.Application.Common.Interfaces;
using Algolia.Core.Domain.Models;
using Newtonsoft.Json;

namespace Algolia.Core.Infrastructure.Repositories
{
    public class AlgoliaRepository : IAlgoliaRepository
    {
        public async Task<AlgoliaLocation> SearchLocationByObjectId(string objectId, CancellationToken cancellationToken)
        {
            var algoliaLocation = new AlgoliaLocation();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(
                    $"https://places-dsn.algolia.net/1/places/{objectId}", cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var responceContent = await response.Content.ReadAsStringAsync();
                    algoliaLocation = JsonConvert.DeserializeObject<AlgoliaLocation>(responceContent);
                }
            }

            return algoliaLocation;
        }

        public async Task<List<Hit>> SearchLocationsByName(string name, CancellationToken cancellationToken)
        {
            var algoliaResponce = new AlgoliaResponce();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(
                    $"https://places-dsn.algolia.net/1/places/query?query={name}&type=city&language=ua", cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var responceContent = await response.Content.ReadAsStringAsync();
                    algoliaResponce = JsonConvert.DeserializeObject<AlgoliaResponce>(responceContent);
                }
            }

            return algoliaResponce.Hits;
        }
    }
}
