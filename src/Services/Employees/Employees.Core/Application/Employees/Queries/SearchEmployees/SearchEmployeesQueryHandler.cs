using AutoMapper;
using Employees.Core.Application.Common.Interfaces;
using Employees.Core.Application.Common.ViewModels;
using MediatR;

namespace Employees.Core.Application.Employees.Queries.SearchEmployees
{
    public class SearchEmployeesQueryHandler : IRequestHandler<SearchEmployeesQuery, PaginatedEmployeesVM>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public SearchEmployeesQueryHandler(
            IMapper mapper
            , IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }
        public async Task<PaginatedEmployeesVM> Handle(SearchEmployeesQuery request, CancellationToken cancellationToken)
        {
            var paginatedEmployees = await _employeeService
                .SearchEmployees(request.Pattern, request.PageIndex, request.PageSize, cancellationToken);

            return _mapper.Map<PaginatedEmployeesVM>(paginatedEmployees);
        }
    }
}
