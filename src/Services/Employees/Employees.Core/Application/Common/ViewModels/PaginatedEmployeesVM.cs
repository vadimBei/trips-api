using AutoMapper;
using Common.Data.Helpers;
using Employees.Core.Domain.Entities;

namespace Employees.Core.Application.Common.ViewModels
{
    [AutoMap(typeof(PaginatedList<Employee>))]
    public class PaginatedEmployeesVM
    {
        public int PageIndex { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public List<EmployeeVM> Items { get; set; }
    }
}
