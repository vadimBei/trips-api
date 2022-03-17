namespace Employees.Core.Application.Common.Dtos
{
    public class EmployeeToUpdateDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int Age { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
