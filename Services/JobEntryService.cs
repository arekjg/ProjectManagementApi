using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Data;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Dtos.JobEntry;
using ProjectManagementApi.Interfaces;
using ProjectManagementApi.Models;
using System.Net;

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

        public async Task<ServiceResponse<List<GetJobEntryDto>>> AddJobEntry(AddJobEntryDto newJobEntry)
        {
            ServiceResponse<List<GetJobEntryDto>> serviceResponse = new ServiceResponse<List<GetJobEntryDto>>();
            try
            {
                await _context.JobEntries.AddAsync(_mapper.Map<JobEntry>(newJobEntry));
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.JobEntries.Select(je => _mapper.Map<GetJobEntryDto>(je)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetJobEntryDto>>> DeleteJobEntry(int id)
        {
            ServiceResponse<List<GetJobEntryDto>> serviceResponse = new ServiceResponse<List<GetJobEntryDto>>();
            try
            {
                var jobEntry = await _context.JobEntries.FirstOrDefaultAsync(je => je.Id == id);
                if (jobEntry != null)
                {
                    _context.JobEntries.Remove(jobEntry);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.JobEntries.Select(je => _mapper.Map<GetJobEntryDto>(je)).ToListAsync();
                }
                else
                {
                    serviceResponse.Code = HttpStatusCode.NotFound;
                    serviceResponse.Message = $"Job entry with ID = {id} not found.";
                }
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetJobEntryDto>>> GetAllJobEntries()
        {
            ServiceResponse<List<GetJobEntryDto>> serviceResponse = new ServiceResponse<List<GetJobEntryDto>>();
            try
            {
                var jobEntries = await _context.JobEntries.Select(je => _mapper.Map<GetJobEntryDto>(je)).ToListAsync();
                serviceResponse.Data = jobEntries;
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<List<GetJobEntryDto>>> GetJobEntriesByJobId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetJobEntryDto>>> GetJobEntriesByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetJobEntryDto>> GetJobEntryById(int id)
        {
            ServiceResponse<GetJobEntryDto> serviceResponse = new ServiceResponse<GetJobEntryDto>();
            try
            {
                var jobEntry = _mapper.Map<GetJobEntryDto>(await _context.JobEntries
                    .Include(je => je.User)
                    .Include(je => je.Job)
                    .FirstOrDefaultAsync(je => je.Id == id));
                if (jobEntry != null)
                {
                    serviceResponse.Data = jobEntry;
                }
                else
                {
                    serviceResponse.Code = HttpStatusCode.NotFound;
                    serviceResponse.Message = $"Job Entry with ID = {id} not found.";
                }
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<GetJobEntryDto>> UpdateJobEntry(UpdateJobEntryDto updatedJobEntry)
        {
            throw new NotImplementedException();
        }
    }
}
