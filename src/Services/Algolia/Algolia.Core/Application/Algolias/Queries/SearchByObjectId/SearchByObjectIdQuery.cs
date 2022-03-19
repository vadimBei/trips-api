using Algolia.Core.Application.Common.ViewModels;
using MediatR;

namespace Algolia.Core.Application.Algolias.Queries.SearchByObjectId
{
    public class SearchByObjectIdQuery : IRequest<LocationVM>
    {
        public string ObjectId { get; set; }
    }
}
