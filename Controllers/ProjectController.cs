using Microsoft.AspNetCore.Mvc;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Interfaces;

namespace ProjectManagementApi.Controllers
{
    [Route("api/Projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _projectService.GetAllProjects());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _projectService.GetProjectById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProjectDto newProject)
        {
            return Ok(await _projectService.AddProject(newProject));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateProjectDto updatedProject)
        {
            return Ok(await _projectService.UpdateProject(updatedProject));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _projectService.DeleteProject(id));
        }
    }
}
