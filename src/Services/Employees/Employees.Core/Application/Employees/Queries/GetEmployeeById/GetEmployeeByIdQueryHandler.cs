using AutoMapper;
using Employees.Core.Application.Common.Interfaces;
using Employees.Core.Application.Common.ViewModels;
using MediatR;

namespace Employees.Core.Application.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeVM>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public GetEmployeeByIdQueryHandler(
            IMapper mapper
            , IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        public async Task<EmployeeVM> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeService
                .GetEmployeeById(request.Id, cancellationToken);

            return _mapper.Map<EmployeeVM>(employee);
        }
    }
}
