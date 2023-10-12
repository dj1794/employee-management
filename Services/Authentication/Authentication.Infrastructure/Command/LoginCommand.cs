using Authentication.Application.Model;
using Authentication.Domain;
using Authentication.Infrastructure.Configuration.Database;
using Authentication.Infrastructure.Utility;
using BuildingBlock.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Command
{
    public class LoginCommand:ICommand<string>
    {
       public  LoginModel LoginModel { get; set; }
        public LoginCommand(LoginModel loginModel)
        {
            LoginModel = loginModel;
        }
    }
    public class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IJwtService _jwtService;
        public LoginCommandHandler(IRepository<User> userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.Table.FirstOrDefaultAsync(user => user.Email == request.LoginModel.Email && user.Password == request.LoginModel.Password);
            if (existingUser != null)
            {
                var token = _jwtService.GenerateJwtToken(existingUser);
                return token;
            }
            else
            {
                throw new UnauthorizedAccessException("Username or Password is not valid");
            }
        }
    }
}
