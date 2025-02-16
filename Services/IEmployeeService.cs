using ProjectManagerApi.Models;

namespace ProjectManagerApi.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<object>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
