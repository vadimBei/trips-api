using Common.Data.Exceptions;
using Common.Data.Helpers;
using Employees.Core.Application.Common.Dtos;
using Employees.Core.Application.Common.Interfaces;
using Employees.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employees.Core.Application.Common.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IApplicationDbContext _context;

        public EmployeeService(
            IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployee(EmployeeToCreateDto dto, CancellationToken cancellationToken)
        {
            var employee = new Employee()
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Age = dto.Age,
                DateOfBirth = dto.DateOfBirth,
                Email = dto.Email,
                Phone = dto.Phone
            };

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync(cancellationToken);

            return employee;
        }

        public async Task DeleteEmployee(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Employees
                .SingleOrDefaultAsync(employee => employee.Id == id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), id);
            }

            _context.Employees.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Employee> GetEmployeeById(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Employees
                .SingleOrDefaultAsync(employee => employee.Id == id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), id);
            }

            return entity;
        }

        public async Task<PaginatedList<Employee>> GetEmployees(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var entities = _context.Employees
                .AsQueryable();

            return await PaginatedList<Employee>.CreateAsync(entities, pageIndex, pageSize);
        }

        public async Task<Employee> UpdateEmployee(EmployeeToUpdateDto dto, CancellationToken cancellationToken)
        {
            var entity = await _context.Employees
                 .SingleOrDefaultAsync(employee => employee.Id == dto.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), dto.Id);
            }

            entity.Name = dto.Name;
            entity.LastName = dto.LastName;
            entity.DateOfBirth = dto.DateOfBirth;
            entity.Email = dto.Email;
            entity.Phone = dto.Phone;
            entity.Age = dto.Age;

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
