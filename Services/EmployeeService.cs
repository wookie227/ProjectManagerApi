using ProjectManagerApi.Models;
using ProjectManagerApi.Repositories;

namespace ProjectManagerApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // Получение всех сотрудников
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        // Получение сотрудника по ID
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        // Добавление нового сотрудника
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            // Можно добавить дополнительную бизнес-логику, например, проверку данных
            return await _employeeRepository.AddEmployeeAsync(employee);
        }

        // Обновление информации о сотруднике
        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            // Можно добавить логику для проверки, что сотрудник существует и может быть обновлен
            return await _employeeRepository.UpdateEmployeeAsync(employee);
        }

        // Удаление сотрудника по ID
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            // Можно добавить проверку, что сотрудник существует перед удалением
            return await _employeeRepository.DeleteEmployeeAsync(id);
        }
    }
}
