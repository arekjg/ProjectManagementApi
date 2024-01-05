﻿using AutoMapper;
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
            return _context.JobEntries.Select(je => _mapper.Map<GetJobEntryDto>(je)).ToList();
        }

        public async Task<List<GetJobEntryDto>> DeleteJobEntry(int id)
        {
            var jobEntry = await _context.JobEntries.FirstOrDefaultAsync(je => je.Id == id);
            if (jobEntry != null)
            {
                _context.JobEntries.Remove(jobEntry);
                await _context.SaveChangesAsync();
            }
            
            return await _context.JobEntries.Select(je => _mapper.Map<GetJobEntryDto>(je)).ToListAsync();
        }

        public async Task<List<GetJobEntryDto>> GetAllJobEntries()
        {
            return await _context.JobEntries.Select(je => _mapper.Map<GetJobEntryDto>(je)).ToListAsync();
        }

        public async Task<List<GetJobEntryDto>> GetJobEntriesByJobId(int id)
        {
            return await _context.JobEntries
                .Where(je => je.JobId == id)
                .Select(je => _mapper.Map<GetJobEntryDto>(je))
                .ToListAsync();
        }

        public async Task<List<GetJobEntryDto>> GetJobEntriesByUserId(int id)
        {
            return await _context.JobEntries
                .Where(je => je.UserId == id)
                .Select(je => _mapper.Map<GetJobEntryDto>(je))
                .ToListAsync();
        }

        public async Task<GetJobEntryDto> GetJobEntryById(int id)
        {
            return _mapper.Map<GetJobEntryDto>(await _context.JobEntries
                .Include(je => je.User)
                .Include(je => je.Job)
                .FirstOrDefaultAsync(je => je.Id == id));
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
