using Authentication.Application.Model;
using Authentication.Infrastructure;
using Authentication.Infrastructure.Command;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        AuthenticationModule _module;
        public UserController(AuthenticationModule module)
        {
            _module = module;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateUser(CreateUserModel createUserModel)
        {
            var result = await _module.ExecuteCommandAsync(new CreateUserCommand(createUserModel));
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            var result = await _module.ExecuteCommandAsync(new LoginCommand(loginModel));
            return Ok(result);
        }
    }
}
