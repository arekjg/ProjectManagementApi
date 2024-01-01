using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Data;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Interfaces;
using ProjectManagementApi.Models;
using System.Net;

namespace ProjectManagementApi.Services
{
    public class JobService : IJobService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public JobService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetJobDto>>> AddJob(AddJobDto newJob)
        {
            ServiceResponse<List<GetJobDto>> serviceResponse = new ServiceResponse<List<GetJobDto>>();
            try
            {
                await _context.Jobs.AddAsync(_mapper.Map<Job>(newJob));
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Jobs.Select(j => _mapper.Map<GetJobDto>(j)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetJobDto>>> DeteleJob(int id)
        {
            ServiceResponse<List<GetJobDto>> serviceResponse = new ServiceResponse<List<GetJobDto>>();
            try
            {
                var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id);
                if (job != null)
                {
                    _context.Jobs.Remove(job);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Jobs.Select(j => _mapper.Map<GetJobDto>(j)).ToListAsync();
                }
                else
                {
                    serviceResponse.Code = HttpStatusCode.NotFound;
                    serviceResponse.Message = $"Job with ID = {id} not found.";
                }
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetJobDto>>> GetAllJobs()
        {
            ServiceResponse<List<GetJobDto>> serviceResponse = new ServiceResponse<List<GetJobDto>>();
            try
            {
                var jobs = await _context.Jobs.Select(j => _mapper.Map<GetJobDto>(j)).ToListAsync();
                serviceResponse.Data = jobs;
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetJobDto>> GetJobById(int id)
        {
            ServiceResponse<GetJobDto> serviceResponse = new ServiceResponse<GetJobDto>();
            try
            {
                // TODO: include children in other methods and entities

                var job = _mapper.Map<GetJobDto>(await _context.Jobs
                    .Include(j => j.CreatedBy)
                    .Include(j => j.Project)
                    .FirstOrDefaultAsync(j => j.Id == id));
                if (job != null)
                {
                    serviceResponse.Data = job;
                }
                else
                {
                    serviceResponse.Code = HttpStatusCode.NotFound;
                    serviceResponse.Message = $"Job with ID = {id} not found.";
                }
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetJobDto>>> GetJobsByProjectId(int id)
        {
            ServiceResponse<List<GetJobDto>> serviceResponse = new ServiceResponse<List<GetJobDto>>();
            try
            {
                var jobs = await _context.Jobs
                    .Where(j => j.ProjectId == id)
                    .Select(j => _mapper.Map<GetJobDto>(j))
                    .ToListAsync();
                serviceResponse.Data = jobs;
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetJobDto>>> GetJobsByUserId(int id)
        {
            ServiceResponse<List<GetJobDto>> serviceResponse = new ServiceResponse<List<GetJobDto>>();
            try
            {
                var jobs = await _context.Jobs
                    .Join(
                        _context.JobEntries,
                        j => j.Id,
                        je => je.JobId,
                        (j, je) => new { Job = j, JobEntry = je }
                    )
                    .Where(joined => joined.JobEntry.UserId == id)
                    .Select(joined => _mapper.Map<GetJobDto>(joined.Job))
                    .ToListAsync();

                serviceResponse.Data = jobs;
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetJobDto>> UpdateJob(UpdateJobDto updatedJob)
        {
            ServiceResponse<GetJobDto> serviceResponse = new ServiceResponse<GetJobDto>();
            try
            {
                var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == updatedJob.Id);
                if (job != null)
                {
                    job.Name = updatedJob.Name;
                    job.Description = updatedJob.Description;
                    job.Status = updatedJob.Status;
                    job.DeadlineDate = updatedJob.DeadlineDate;
                    job.Priority = updatedJob.Priority;

                    _context.Jobs.Update(job);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetJobDto>(job);
                }
                else
                {
                    serviceResponse.Code = HttpStatusCode.NotFound;
                    serviceResponse.Message = $"Job with ID = {updatedJob.Id} not found.";
                }
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }
    }
}
