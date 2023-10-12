using HrmUi.Model;

namespace HrmUi.IService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeWorkLogModel>> GetWorkLog();
        Task<EmployeeModel> AddEmployee(EmployeeModel employee);
    }
}
