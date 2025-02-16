using ProjectManagerApi.Models;

namespace ProjectManagerApi.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<object>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
