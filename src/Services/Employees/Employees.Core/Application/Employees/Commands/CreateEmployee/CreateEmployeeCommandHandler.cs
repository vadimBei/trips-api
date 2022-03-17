using AutoMapper;
using Employees.Core.Application.Common.Dtos;
using Employees.Core.Application.Common.Interfaces;
using Employees.Core.Application.Common.ViewModels;
using MediatR;

namespace Employees.Core.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeVM>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public CreateEmployeeCommandHandler(
            IMapper mapper
            , IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        public async Task<EmployeeVM> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var dto = new EmployeeToCreateDto()
            {
                Name = request.Name,
                LastName = request.LastName,
                Age = request.Age,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                Phone = request.Phone
            };

            var newEmployee = await _employeeService
                .CreateEmployee(dto, cancellationToken);

            return _mapper.Map<EmployeeVM>(newEmployee);
        }
    }
}
