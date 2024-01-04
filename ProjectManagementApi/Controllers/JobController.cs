using Microsoft.AspNetCore.Mvc;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Helper;
using ProjectManagementApi.Interfaces;

namespace ProjectManagementApi.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<GetJobDto> jobs = await _jobService.GetAllJobs();
                return ResponseUtility.OkOrNotFound(jobs);
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
                GetJobDto job = await _jobService.GetJobById(id);
                return ResponseUtility.OkOrNotFound(job);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpGet("project/{id}")]
        public async Task<IActionResult> GetByProjectId(int id)
        {
            try
            {
                List<GetJobDto> jobs = await _jobService.GetJobsByProjectId(id);
                return ResponseUtility.OkOrNotFound(jobs);
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
                List<GetJobDto> jobs = await _jobService.GetJobsByUserId(id);
                return ResponseUtility.OkOrNotFound(jobs);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddJobDto newJob)
        {
            try
            {
                return Ok(await _jobService.AddJob(newJob));
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateJobDto updatedJob)
        {
            try
            {
                return Ok(await _jobService.UpdateJob(updatedJob));
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
                List<GetJobDto> jobs = await _jobService.DeleteJob(id);
                return ResponseUtility.OkOrNotFound(jobs);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }
    }
}
