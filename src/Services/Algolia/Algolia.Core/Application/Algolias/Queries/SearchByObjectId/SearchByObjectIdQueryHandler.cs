using Algolia.Core.Application.Common.Interfaces;
using Algolia.Core.Application.Common.ViewModels;
using AutoMapper;
using MediatR;

namespace Algolia.Core.Application.Algolias.Queries.SearchByObjectId
{
    public class SearchByObjectIdQueryHandler : IRequestHandler<SearchByObjectIdQuery, LocationVM>
    {
        private readonly IMapper _mapper;
        private readonly IAlgoliaService _algoliaService;

        public SearchByObjectIdQueryHandler(
            IMapper mapper,
            IAlgoliaService algoliaService)
        {
            _mapper = mapper;
            _algoliaService = algoliaService;
        }

        public async Task<LocationVM> Handle(SearchByObjectIdQuery request, CancellationToken cancellationToken)
        {
            var location = await _algoliaService
                .SearchLocationByObjectId(request.ObjectId, cancellationToken);

            return _mapper.Map<LocationVM>(location);
        }
    }
}
