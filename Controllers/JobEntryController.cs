using Microsoft.AspNetCore.Mvc;
using ProjectManagementApi.Dtos.JobEntry;
using ProjectManagementApi.Interfaces;

namespace ProjectManagementApi.Controllers
{
    [Route("api/jobEntries")]
    [ApiController]
    public class JobEntryController : ControllerBase
    {
        // TODO: complete the controller, other GET methods and PUT method
        // TODO: Test the controller

        private readonly IJobEntryService _jobEntryService;
        public JobEntryController(IJobEntryService jobEntryService)
        {
            _jobEntryService = jobEntryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _jobEntryService.GetAllJobEntries());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _jobEntryService.GetJobEntryById(id));
        }



        [HttpPost]
        public async Task<IActionResult> Add(AddJobEntryDto newJobEntry)
        {
            return Ok(await _jobEntryService.AddJobEntry(newJobEntry));
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _jobEntryService.DeleteJobEntry(id));
        }

    }
}
