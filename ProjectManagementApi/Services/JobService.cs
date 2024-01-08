using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Data;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Interfaces;
using ProjectManagementApi.Models;

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

        public async Task<List<GetJobDto>> AddJob(AddJobDto newJob)
        {
            await _context.Jobs.AddAsync(_mapper.Map<Job>(newJob));
            await _context.SaveChangesAsync();

            var jobs = await _context.Jobs.ToListAsync();
            return _mapper.Map<List<GetJobDto>>(jobs);
        }

        public async Task<List<GetJobDto>> DeleteJob(int id)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }

            var jobs = await _context.Jobs.ToListAsync();
            return _mapper.Map<List<GetJobDto>>(jobs);
        }

        public async Task<List<GetJobDto>> GetAllJobs()
        {
            var jobs = await _context.Jobs.ToListAsync();
            return _mapper.Map<List<GetJobDto>>(jobs);
        }

        public async Task<GetJobDto> GetJobById(int id)
        {
            var job = await _context.Jobs
                .Include(j => j.CreatedBy)
                .Include(j => j.Project)
                .FirstOrDefaultAsync(j => j.Id == id);
            return _mapper.Map<GetJobDto>(job);
        }

        public async Task<List<GetJobDto>> GetJobsByProjectId(int id)
        {
            var jobs = await _context.Jobs
                .Where(j => j.ProjectId == id)
                .ToListAsync();
            return _mapper.Map<List<GetJobDto>>(jobs);
        }

        public async Task<List<GetJobDto>> GetJobsByUserId(int id)
        {
            return await _context.Jobs
                .Join(
                    _context.JobEntries,
                    j => j.Id,
                    je => je.JobId,
                    (j, je) => new { Job = j, JobEntry = je }
                )
                .Where(joined => joined.JobEntry.UserId == id)
                .Select(joined => _mapper.Map<GetJobDto>(joined.Job))
                .ToListAsync();
        }

        public async Task<GetJobDto> UpdateJob(UpdateJobDto updatedJob)
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
            }
            return _mapper.Map<GetJobDto>(job);
        }
    }
}
