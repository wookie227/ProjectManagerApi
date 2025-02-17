using ProjectManagerApi.Models;
using ProjectManagerApi.Repositories;

namespace ProjectManagerApi.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<object>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllProjectsAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _projectRepository.GetProjectByIdAsync(id);
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            return await _projectRepository.AddProjectAsync(project);
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            return await _projectRepository.UpdateProjectAsync(project);
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            return await _projectRepository.DeleteProjectAsync(id);
        }

        public async Task<bool> AddEmployeeToProjectAsync(int projectId, int employeeId)
        {
            return await _projectRepository.AddEmployeeToProjectAsync(projectId, employeeId);
        }

        public async Task<bool> DeleteEmployeeFromProjectAsync(int projectId, int employeeId)
        {
            return await _projectRepository.DeleteEmployeeFromProjectAsync(projectId, employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesForProjectAsync(int projectId)
        {
            return await _projectRepository.GetEmployeesForProjectAsync(projectId);
        }

        public async Task<Project?> UpdateProjectFilePathAsync(int projectId, string filePath)
        {
            return await _projectRepository.UpdateProjectFilePathAsync(projectId, filePath);
        }
    }
}
