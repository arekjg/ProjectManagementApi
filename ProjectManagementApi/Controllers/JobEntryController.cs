using Microsoft.AspNetCore.Mvc;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Helper;
using ProjectManagementApi.Interfaces;

namespace ProjectManagementApi.Controllers
{
    [Route("api/jobEntries")]
    [ApiController]
    public class JobEntryController : ControllerBase
    {
        // TODO: Test the controller

        private readonly IJobEntryService _jobEntryService;
        public JobEntryController(IJobEntryService jobEntryService)
        {
            _jobEntryService = jobEntryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<GetJobEntryDto> jobEntries = await _jobEntryService.GetAllJobEntries();
                return ResponseUtility.OkOrNotFound(jobEntries);
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
                GetJobEntryDto jobEntry = await _jobEntryService.GetJobEntryById(id);
                return ResponseUtility.OkOrNotFound(jobEntry);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpGet("job/{id}")]
        public async Task<IActionResult> GetByJobId(int id)
        {
            try
            {
                List<GetJobEntryDto> jobEntries = await _jobEntryService.GetJobEntriesByJobId(id);
                return ResponseUtility.OkOrNotFound(jobEntries);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            try
            {
                List<GetJobEntryDto> jobEntries = await _jobEntryService.GetJobEntriesByUserId(id);
                return ResponseUtility.OkOrNotFound(jobEntries);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddJobEntryDto newJobEntry)
        {
            try
            {
                return Ok(await _jobEntryService.AddJobEntry(newJobEntry));
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateJobEntryDto updatedJobEntry)
        {
            try
            {
                return Ok(await _jobEntryService.UpdateJobEntry(updatedJobEntry));
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
                List<GetJobEntryDto> jobEntries = await _jobEntryService.DeleteJobEntry(id);
                return ResponseUtility.OkOrNotFound(jobEntries);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

    }
}
