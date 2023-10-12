using Authentication.Application.Model;
using BuildingBlock.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain
{
    public class User:DomainBase
    {
        public long EmployeeId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public static User Create(CreateUserModel userModel)
        {
            return new User()
            {
                EmployeeId = userModel.EmployeeId,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Phone = userModel.Phone,
                Email = userModel.Email,
                Password = userModel.Password

            };
        }
    }
}
