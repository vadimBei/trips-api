using Algolia.Core.Application.Algolias.Queries.SearchByName;
using Algolia.Core.Application.Algolias.Queries.SearchByObjectId;
using Algolia.Core.Application.Common.ViewModels;
using Common.Kernel.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Algolia.Api.Controllers
{
    [Route("api/algolia/search")]
    public class AlgoliaController : ApiController
    {
        [HttpGet("by-name")]
        public async Task<List<LocationVM>> SearchByName(string name)
             => await Mediator.Send(new SearchByNameQuery()
             {
                 Name = name
             });

        [HttpGet("by-objectId")]
        public async Task<LocationVM> SearchByObjectId(string objectId)
            => await Mediator.Send(new SearchByObjectIdQuery()
            {
                ObjectId = objectId
            });
    }
}
