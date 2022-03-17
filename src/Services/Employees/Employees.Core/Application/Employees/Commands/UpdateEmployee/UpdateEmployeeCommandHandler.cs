using AutoMapper;
using Employees.Core.Application.Common.Dtos;
using Employees.Core.Application.Common.Interfaces;
using Employees.Core.Application.Common.ViewModels;
using MediatR;

namespace Employees.Core.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeVM>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public UpdateEmployeeCommandHandler(
            IMapper mapper
            , IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        public async Task<EmployeeVM> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var dto = new EmployeeToUpdateDto()
            {
                Id = request.Id,
                Name = request.Name,
                LastName = request.LastName,
                Age = request.Age,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                Phone = request.Phone
            };

            var updatedEmployee = await _employeeService
                .UpdateEmployee(dto, cancellationToken);

            return _mapper.Map<EmployeeVM>(updatedEmployee);
        }
    }
}
