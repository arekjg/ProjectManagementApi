﻿using Microsoft.AspNetCore.Mvc;
using ProjectManagementApi.Dtos;
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
            return Ok(await _jobService.GetAllJobs());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _jobService.GetJobById(id));
        }

        [HttpGet("project/{id}")]
        public async Task<IActionResult> GetByProjectId(int id)
        {
            return Ok(await _jobService.GetJobsByProjectId(id));
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            return Ok(await _jobService.GetJobsByUserId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddJobDto newJob)
        {
            return Ok(await _jobService.AddJob(newJob));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateJobDto updatedJob)
        {
            return Ok(await _jobService.UpdateJob(updatedJob));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _jobService.DeteleJob(id));
        }
    }
}
