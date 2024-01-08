using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Data;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Interfaces;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Services
{
    public class JobEntryService : IJobEntryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public JobEntryService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetJobEntryDto>> AddJobEntry(AddJobEntryDto newJobEntry)
        {
            await _context.JobEntries.AddAsync(_mapper.Map<JobEntry>(newJobEntry));
            await _context.SaveChangesAsync();

            var jobEntries = await _context.JobEntries.ToListAsync();
            return _mapper.Map<List<GetJobEntryDto>>(jobEntries);
        }

        public async Task<List<GetJobEntryDto>> DeleteJobEntry(int id)
        {
            var jobEntry = await _context.JobEntries.FirstOrDefaultAsync(je => je.Id == id);
            if (jobEntry != null)
            {
                _context.JobEntries.Remove(jobEntry);
                await _context.SaveChangesAsync();
            }

            var jobEntries = await _context.JobEntries.ToListAsync();
            return _mapper.Map<List<GetJobEntryDto>>(jobEntries);
        }

        public async Task<List<GetJobEntryDto>> GetAllJobEntries()
        {
            var jobEntries = await _context.JobEntries.ToListAsync();
            return _mapper.Map<List<GetJobEntryDto>>(jobEntries);
        }

        public async Task<List<GetJobEntryDto>> GetJobEntriesByJobId(int id)
        {
            var jobEntries = await _context.JobEntries
                .Where(je => je.JobId == id)
                .ToListAsync();
            return _mapper.Map<List<GetJobEntryDto>>(jobEntries);
        }

        public async Task<List<GetJobEntryDto>> GetJobEntriesByUserId(int id)
        {
            var jobEntries = await _context.JobEntries
                .Where(je => je.UserId == id)
                .ToListAsync();
            return _mapper.Map<List<GetJobEntryDto>>(jobEntries);
        }

        public async Task<GetJobEntryDto> GetJobEntryById(int id)
        {
            var jobEntry = await _context.JobEntries
                .Include(je => je.User)
                .Include(je => je.Job)
                .FirstOrDefaultAsync(je => je.Id == id);
            return _mapper.Map<GetJobEntryDto>(jobEntry);
        }

        public async Task<GetJobEntryDto> UpdateJobEntry(UpdateJobEntryDto updatedJobEntry)
        {
            var jobEntry = await _context.JobEntries.FirstOrDefaultAsync(je => je.Id == updatedJobEntry.Id);
            if (jobEntry != null)
            {
                jobEntry.EndedAtDate = updatedJobEntry.EndedAtDate;
                jobEntry.EndedAtTime = updatedJobEntry.EndedAtTime;

                _context.JobEntries.Update(jobEntry);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<GetJobEntryDto>(jobEntry);
        }
    }
}
