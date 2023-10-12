using BuildingBlock.Contract;
using Authentication.Infrastructure.Configuration.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Application.Model;
using Authentication.Domain;

namespace Authentication.Infrastructure.Command
{
    public class CreateUserCommand:ICommand<bool>
    {
        public CreateUserModel CreateUserModel { get; set; }
        public CreateUserCommand(CreateUserModel createUserModel) {
           CreateUserModel = createUserModel;
        }

    }
    public class CreateEmployeeCommandHandler : ICommandHandler<CreateUserCommand, bool>
    {
        private readonly IRepository<User> _userRepository;
        public CreateEmployeeCommandHandler(IRepository<User> employeeRepository)
        {
            _userRepository = employeeRepository;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var IsEmailExist = _userRepository.Table.Any(emp => emp.Email == request.CreateUserModel.Email);
            if(IsEmailExist) {
                return await Task.FromResult(false);
            }
            var newEmployee = User.Create(request.CreateUserModel);
            await _userRepository.AddAsync(newEmployee);
            return await Task.FromResult(true);

        }
    }
}
