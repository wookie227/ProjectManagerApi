using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.Database;
using ProjectManagerApi.Models;

namespace ProjectManagerApi.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetAllProjectsAsync()
        {
            return await _context.Projects
                .Include(p => p.CustomerCompany)
                .Include(p => p.ExecutorCompany)
                .Include(p => p.ProjectManager)
                .Select(p => new
                {
                    p.Id,
                    p.ProjectName,
                    CustomerCompanyName = p.CustomerCompany.Name,
                    ExecutorCompanyName = p.ExecutorCompany.Name,
                    p.StartDate,
                    p.EndDate,
                    p.Priority,
                    ProjectManagerName = p.ProjectManager.FirstName + " " + p.ProjectManager.LastName
                })
                .ToListAsync();
        }



        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return false;

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddEmployeeToProjectAsync(int projectId, int employeeId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            var employee = await _context.Employees.FindAsync(employeeId);

            if (project == null || employee == null)
                return false;

            var projectEmployee = new ProjectEmployee
            {
                ProjectId = projectId,
                EmployeeId = employeeId
            };

            _context.ProjectEmployees.Add(projectEmployee);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteEmployeeFromProjectAsync(int projectId, int employeeId)
        {
            var projectEmployee = await _context.ProjectEmployees
                .FirstOrDefaultAsync(pe => pe.ProjectId == projectId && pe.EmployeeId == employeeId);

            if (projectEmployee == null)
                return false;

            _context.ProjectEmployees.Remove(projectEmployee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesForProjectAsync(int projectId)
        {
            var projectEmployees = await _context.ProjectEmployees
                .Where(pe => pe.ProjectId == projectId)
                .Include(pe => pe.Employee)
                .Select(pe => pe.Employee)
                .ToListAsync();

            return projectEmployees;
        }

    }
}
