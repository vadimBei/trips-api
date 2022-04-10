using Common.Kernel.Controllers;
using Employees.Core.Application.Common.ViewModels;
using Employees.Core.Application.Employees.Commands.CreateEmployee;
using Employees.Core.Application.Employees.Commands.DeleteEmployee;
using Employees.Core.Application.Employees.Commands.UpdateEmployee;
using Employees.Core.Application.Employees.Queries.GetAllEmployees;
using Employees.Core.Application.Employees.Queries.GetEmployeeById;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Api.Controllers
{
    [Route("api/employees")]
    public class EmployeesController : ApiController
    {
        [HttpPost("create")]
        public async Task<EmployeeVM> CreateEmployee(CreateEmployeeCommand command)
            => await Mediator.Send(command);

        [HttpGet("by-id/{id}")]
        public async Task<EmployeeVM> GetEmployeeById(Guid id)
            => await Mediator.Send(new GetEmployeeByIdQuery()
            {
                Id = id
            });

        [HttpGet("all")]
        public async Task<PaginatedEmployeesVM> GetAllEmployees(int pageIndex, int pageSize)
            => await Mediator.Send(new GetAllEmployeesQuery()
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            });

        [HttpDelete("delete")]
        public async Task DeleteEmployee(Guid id)
            => await Mediator.Send(new DeleteEmployeeCommand()
            {
                Id = id
            });

        [HttpPost("update")]
        public async Task<EmployeeVM> UpdateEmployee(UpdateEmployeeCommand command)
            => await Mediator.Send(command);
    }
}
