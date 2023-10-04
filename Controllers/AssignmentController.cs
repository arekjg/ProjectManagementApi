using Microsoft.AspNetCore.Mvc;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Interfaces;

namespace ProjectManagementApi.Controllers
{
    [Route("api/Assignments")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentController(IAssignmentService projectService)
        {
            _assignmentService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _assignmentService.GetAllAssignments());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _assignmentService.GetAssignmentById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAssignmentDto newAssignment)
        {
            return Ok(await _assignmentService.AddAssignment(newAssignment));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateAssignmentDto updatedAssignment)
        {
            return Ok(await _assignmentService.UpdateAssignment(updatedAssignment));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _assignmentService.DeleteAssignment(id));
        }
    }
}
