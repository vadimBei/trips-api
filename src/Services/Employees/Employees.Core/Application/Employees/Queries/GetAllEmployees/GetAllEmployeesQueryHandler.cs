using AutoMapper;
using Employees.Core.Application.Common.Interfaces;
using Employees.Core.Application.Common.ViewModels;
using MediatR;

namespace Employees.Core.Application.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, PaginatedEmployeesVM>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public GetAllEmployeesQueryHandler(
            IMapper mapper
            , IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        public async Task<PaginatedEmployeesVM> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var paginatedEmployees = await _employeeService
                .GetEmployees(request.PageIndex, request.PageSize, cancellationToken);

            var vm = new PaginatedEmployeesVM();
            try
            {
                vm = _mapper.Map<PaginatedEmployeesVM>(paginatedEmployees);
            }
            catch (Exception ex)
            {

            }

            return vm;
        }
    }
}
