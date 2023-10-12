using BuildingBlock.Infrastructure;
using Employee.Application.Model;
using System.Diagnostics.Tracing;

namespace Employee.Domain
{
    public class Employees:DomainBase
    {
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
        public Employees()
        {
            IsDeleted = false;
        }
        public static Employees Create(CreateEmployeeModel employeeModel)
        {
            return new Employees() {
                FirstName = employeeModel.FirstName,
                LastName = employeeModel.LastName,
                Phone = employeeModel.Phone,
                Email = employeeModel.Email,
                Title = employeeModel.Title,
                DateOfBirth = employeeModel.DateOfBirth,
                DateOfJoining = employeeModel.DateOfJoining,
                Address = employeeModel.Address,
                City = employeeModel.City,
                PostalCode = employeeModel.PostalCode,
                Country = employeeModel.Country
            };
        }
    }
}