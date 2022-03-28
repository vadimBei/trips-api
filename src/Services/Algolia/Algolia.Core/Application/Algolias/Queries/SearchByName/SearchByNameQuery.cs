using Algolia.Core.Application.Common.ViewModels;
using MediatR;

namespace Algolia.Core.Application.Algolias.Queries.SearchByName
{
    public class SearchByNameQuery : IRequest<List<LocationVM>>
    {
        public string Name { get; set; }
    }
}
