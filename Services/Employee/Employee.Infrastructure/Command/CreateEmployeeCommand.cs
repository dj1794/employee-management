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

namespace Employee.Infrastructure.Command
{
    public class CreateEmployeeCommand:ICommand<Result<bool>>
    {
        public CreateEmployeeModel CreateEmployeeModel { get; set; }
        public CreateEmployeeCommand(CreateEmployeeModel createEmployeeModel) {
           CreateEmployeeModel = createEmployeeModel;
        }

    }
    public class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, Result<bool>>
    {
        private readonly IRepository<Employees> _employeeRepository;
        public CreateEmployeeCommandHandler(IRepository<Employees> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<bool>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var IsEmailExist = _employeeRepository.Table.Any(emp => emp.Email == request.CreateEmployeeModel.Email);
            if(IsEmailExist) {
                return await Result<bool>.FailedAsync("Email already exist.");
            }
            var newEmployee = Employees.Create(request.CreateEmployeeModel);
            await _employeeRepository.AddAsync(newEmployee);
            return await Result<bool>.SuccessAsync<bool>("Employee added successfully!");

        }
    }
}
