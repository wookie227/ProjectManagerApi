using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.Database;
using ProjectManagerApi.Models;
using ProjectManagerApi.Services;

namespace ProjectManagerApi.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
                return Ok(await _projectService.GetAllProjectsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject([FromBody] Project project)
        {
            var createdProject = await _projectService.AddProjectAsync(project);
            return CreatedAtAction(nameof(GetProject), new { id = createdProject.Id }, createdProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] Project project)
        {
            if (id != project.Id)
                return BadRequest();

            var updatedProject = await _projectService.UpdateProjectAsync(project);
            return Ok(updatedProject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var deleted = await _projectService.DeleteProjectAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPost("{projectId}/employees/{employeeId}")]
        public async Task<IActionResult> AddEmployeeToProject(int projectId, int employeeId)
        {
            var result = await _projectService.AddEmployeeToProjectAsync(projectId, employeeId);
            if (!result)
                return BadRequest("Unable to add employee to project.");

            return Ok();
        }

        [HttpDelete("{projectId}/employees/{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeFromProject(int projectId, int employeeId)
        {
            var result = await _projectService.DeleteEmployeeFromProjectAsync(projectId, employeeId);
            if (!result)
                return NotFound("Employee not found in project.");

            return NoContent();
        }

        [HttpGet("{projectId}/employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesForProject(int projectId)
        {
            var employees = await _projectService.GetEmployeesForProjectAsync(projectId);
            if (employees == null || !employees.Any())
                return NotFound("No employees found for this project.");

            return Ok(employees);
        }

    }
}
