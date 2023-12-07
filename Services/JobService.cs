﻿using AutoMapper;
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

        public async Task<ServiceResponse<List<GetJobDto>>> AddJob(AddJobDto newJob)
        {
            ServiceResponse<List<GetJobDto>> serviceResponse = new ServiceResponse<List<GetJobDto>>();
            await _context.Jobs.AddAsync(_mapper.Map<Job>(newJob));
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Jobs.Select(p => _mapper.Map<GetJobDto>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetJobDto>>> DeteleJob(int id)
        {
            ServiceResponse<List<GetJobDto>> serviceResponse = new ServiceResponse<List<GetJobDto>>();
            try
            {
                var job = await _context.Jobs.FirstOrDefaultAsync(p => p.Id == id);
                if (job != null)
                {
                    _context.Jobs.Remove(job);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Jobs.Select(p => _mapper.Map<GetJobDto>(p)).ToListAsync();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Job not found.";
                }
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetJobDto>>> GetAllJobs()
        {
            ServiceResponse<List<GetJobDto>> serviceResponse = new ServiceResponse<List<GetJobDto>>();
            var jobs = await _context.Jobs.Select(p => _mapper.Map<GetJobDto>(p)).ToListAsync();
            serviceResponse.Data = jobs;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetJobDto>> GetJobById(int id)
        {
            ServiceResponse<GetJobDto> serviceResponse = new ServiceResponse<GetJobDto>();
            var job = _mapper.Map<GetJobDto>(await _context.Jobs.FirstOrDefaultAsync(p => p.Id == id));
            serviceResponse.Data = job;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetJobDto>> UpdateJob(UpdateJobDto updatedJob)
        {
            ServiceResponse<GetJobDto> serviceResponse = new ServiceResponse<GetJobDto>();
            try
            {
                var job = await _context.Jobs.FirstOrDefaultAsync(p => p.Id == updatedJob.Id);
                if (job != null)
                {
                    job.Name = updatedJob.Name;
                    job.Description = updatedJob.Description;
                    job.Status = updatedJob.Status;
                    job.Deadline = updatedJob.Deadline;
                    job.Priority = updatedJob.Priority;

                    _context.Jobs.Update(job);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetJobDto>(job);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Job not found.";
                }
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }
    }
}
