using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Model
{
    public class EmployeeModelDto
    {
        public IEnumerable<EmployeeModel>? Employees { get; set; }
    }
    public class EmployeeModel
    {
        public long  Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required string Title { get; set; }
        public required DateTime DateOfJoining { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
