using HrmUi.IService;
using HrmUi.Model;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace HrmUi.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IApiService _apiClient;
        public EmployeeService(IApiService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException();
        }
        public async Task<EmployeeModel> AddEmployee(EmployeeModel employee)
        {
            var respoonse = await _apiClient.PostAsync("employee/create", employee);
            return respoonse;
        }

        public Task<IEnumerable<EmployeeWorkLogModel>> GetWorkLog()
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<EmployeeWorkLogModel>> GetWorkLog()
        //{
        //    return await httpClient.GetFromJsonAsync<EmployeeWorkLogModel[]>("/worklogs/all");
        //}
    }
}
