using Employees.Core.Application.Common.Interfaces;
using MediatR;

namespace Employees.Core.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IEmployeeService _employeeService;

        public DeleteEmployeeCommandHandler(
            IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _employeeService
                .DeleteEmployee(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
