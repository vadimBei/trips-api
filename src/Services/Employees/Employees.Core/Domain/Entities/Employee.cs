namespace Employees.Core.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string FullName { get => Name + " " + LastName; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int Age { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime? DateOfModification { get; set; }
    }
}
