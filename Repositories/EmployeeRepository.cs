using ProjectManagerApi.Database;
using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.Models;

namespace ProjectManagerApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees
                .Include(e => e.Company)
                .Select(e => new
                {
                    e.Id,
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.Email,
                    CompanyName = e.Company.Name
                })
                .ToListAsync();

            return employees;
        }


        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
