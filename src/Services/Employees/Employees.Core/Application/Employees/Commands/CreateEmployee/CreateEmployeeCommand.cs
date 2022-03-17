using Employees.Core.Application.Common.ViewModels;
using MediatR;

namespace Employees.Core.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<EmployeeVM>
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int Age { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
