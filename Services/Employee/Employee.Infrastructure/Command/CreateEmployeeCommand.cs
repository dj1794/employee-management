using BuildingBlock;
using BuildingBlock.Contract;
using Employee.Application.Model;
using Employee.Domain;
using Employee.Infrastructure.Configuration.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Command
{
    public class CreateEmployeeCommand:ICommand<bool>
    {
        public CreateEmployeeModel CreateEmployeeModel { get; set; }
        public CreateEmployeeCommand(CreateEmployeeModel createEmployeeModel) {
           CreateEmployeeModel = createEmployeeModel;
        }

    }
    public class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, bool>
    {
        private readonly IRepository<Employees> _employeeRepository;
        public CreateEmployeeCommandHandler(IRepository<Employees> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var IsEmailExist = await _employeeRepository.Table.AnyAsync(emp => emp.Email == request.CreateEmployeeModel.Email);
            if(IsEmailExist) {
                return false;
            }
            var newEmployee = Employees.Create(request.CreateEmployeeModel);
            await _employeeRepository.AddAsync(newEmployee);
            return true;

        }
    }
}
