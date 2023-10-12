using Employee.Application.Model;
using Employee.Infrastructure;
using Employee.Infrastructure.Command;
using Employee.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        EmployeeModule _module;
        public EmployeeController(EmployeeModule module)
        {
            _module = module;
        }
        [HttpGet("all")]
        public async Task<ActionResult> GetAllEmployee()
        {
           var data = await _module.ExecuteQueryAsync(new GetAllEmployeesQuery());
           return Ok(data);
        }
        [HttpPost("create")]
        public async Task<ActionResult> CreateEmployee(CreateEmployeeModel createEmployeeModel)
        {
            var result = await _module.ExecuteCommandAsync(new CreateEmployeeCommand(createEmployeeModel));
            return Ok(result);
        }
    }
}
