using BuildingBlock;
using BuildingBlock.Contract;
using Employee.Application.Model;
using Employee.Domain;
using Employee.Infrastructure.Configuration.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Query
{
    public class GetAllEmployeesQuery:IQuery<Result>
    {
    }
    public class GetAllEmployeesQueryHandler : IQueryHandler<GetAllEmployeesQuery, Result>
    {
        private readonly IRepository<Employees> _employeeRepository;
        public GetAllEmployeesQueryHandler(IRepository<Employees> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Result> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var result = _employeeRepository.Table.Select(emp =>new EmployeeModel()            
                        { 
                    Id = emp.Id,
                    FirstName = emp.FirstName, LastName = emp.LastName,Address = emp.Address,
                    DateOfBirth = emp.DateOfBirth, DateOfJoining = emp.DateOfJoining, Email = emp.Email,
                    Phone = emp.Phone, Title = emp.Title, City = emp.City, Country = emp.Country, PostalCode = emp.PostalCode,
            
            }).AsEnumerable();
            var data = new EmployeeModelDto()
            {
                Employees = result
            };
            var res = await Result.SuccessAsync<EmployeeModelDto>(data: data);   
            return res;
        }
    }
}
