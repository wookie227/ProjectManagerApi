using ProjectManagerApi.Models;

namespace ProjectManagerApi.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<object>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<Project> AddProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(Project project);
        Task<bool> DeleteProjectAsync(int id);
        Task<bool> AddEmployeeToProjectAsync(int projectId, int employeeId);
        Task<bool> DeleteEmployeeFromProjectAsync(int projectId, int employeeId);
        Task<IEnumerable<Employee>> GetEmployeesForProjectAsync(int projectId);
        Task<Project?> UpdateProjectFilePathAsync(int projectId, string filePath);
    }
}
