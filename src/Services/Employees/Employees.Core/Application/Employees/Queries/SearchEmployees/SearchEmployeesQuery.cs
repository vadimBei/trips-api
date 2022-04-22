using Employees.Core.Application.Common.ViewModels;
using MediatR;

namespace Employees.Core.Application.Employees.Queries.SearchEmployees
{
    public class SearchEmployeesQuery : IRequest<PaginatedEmployeesVM>
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string Pattern { get; set; }
    }
}
