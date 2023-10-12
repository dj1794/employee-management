using BuildingBlock.Contract;
using Authentication.Infrastructure.Configuration.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Query
{
    //public class GetAllEmployeesQuery:IQuery<EmployeeModelDto>
    //{
    //}
    //public class GetAllEmployeesQueryHandler : IQueryHandler<GetAllEmployeesQuery, EmployeeModelDto>
    //{
    //    private readonly IRepository<Employees> _employeeRepository;
    //    public GetAllEmployeesQueryHandler(IRepository<Employees> employeeRepository)
    //    {
    //        _employeeRepository = employeeRepository;
    //    }
    //    public async Task<EmployeeModelDto> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    //    {
    //        var result = _employeeRepository.Table.Select(emp =>new EmployeeModel()            
    //                    { 
    //                Id = emp.Id,
    //                FirstName = emp.FirstName, LastName = emp.LastName,Address = emp.Address,
    //                DateOfBirth = emp.DateOfBirth, DateOfJoining = emp.DateOfJoining, Email = emp.Email,
    //                Phone = emp.Phone, Title = emp.Title, City = emp.City, Country = emp.Country, PostalCode = emp.PostalCode,
            
    //        }).AsEnumerable();
    //        var data = new EmployeeModelDto()
    //        {
    //            Employees = result
    //        };
    //        return await Task.FromResult(data);   
    //    }
    //}
}
