using Microsoft.AspNetCore.Mvc;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Helper;
using ProjectManagementApi.Interfaces;

namespace ProjectManagementApi.Controllers
{
    [Route("api/projects")]
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
            try
            {
                List<GetProjectDto> projects = await _projectService.GetAllProjects();
                return ResponseUtility.OkOrNotFound(projects);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                GetProjectDto? project = await _projectService.GetProjectById(id);
                return ResponseUtility.OkOrNotFound(project);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpGet("pm/{id}")]
        public async Task<IActionResult> GetByPMId(int id)
        {
            try
            {
                List<GetProjectDto> projects = await _projectService.GetProjectsByPMId(id);
                return ResponseUtility.OkOrNotFound(projects);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProjectDto newProject)
        {
            try
            {
                return Ok(await _projectService.AddProject(newProject));
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateProjectDto updatedProject)
        {
            try
            {
                return Ok(await _projectService.UpdateProject(updatedProject));
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                List<GetProjectDto> projects = await _projectService.DeleteProject(id);
                return ResponseUtility.OkOrNotFound(projects);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }
    }
}
