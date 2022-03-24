using Algolia.Core.Application.Common.Interfaces;
using Algolia.Core.Application.Common.ViewModels;
using AutoMapper;
using MediatR;

namespace Algolia.Core.Application.Algolias.Queries.SearchByName
{
    public class SearchByNameQueryHandler : IRequestHandler<SearchByNameQuery, List<LocationVM>>
    {
        private readonly IMapper _mapper;
        private readonly IAlgoliaService _algoliaService;

        public SearchByNameQueryHandler(
            IMapper mapper
            , IAlgoliaService algoliaService)
        {
            _mapper = mapper;
            _algoliaService = algoliaService;
        }

        public async Task<List<LocationVM>> Handle(SearchByNameQuery request, CancellationToken cancellationToken)
        {
            var locations = await _algoliaService
                .SearchLocationsByName(request.Name, cancellationToken);

            await _algoliaService.CreateLocations(locations, cancellationToken);

            var vm = _mapper.Map<List<LocationVM>>(locations);
            return vm;
        }
    }
}
