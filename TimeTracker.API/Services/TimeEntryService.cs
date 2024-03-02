using Mapster;
using TimeTracker.API.Repositories;
using TimeTracker.Domain.Dto.Request;
using TimeTracker.Domain.Dto.Response;
using TimeTracker.Domain.entities;

namespace TimeTracker.API.Services
{
    public class TimeEntryService : ITimeEntryService
    {
        private readonly ITimeEntryRepository _repository;
        public TimeEntryService(ITimeEntryRepository timeEntryRepository) 
        {
            _repository = timeEntryRepository;
        }
        public async Task<List<TimeEntryDTO>> CreateTimeEntry(TimeEntryCreateRequest request)
        {
            var newItem = request.Adapt<TimeEntry>();
            var result = await _repository.CreateTimeEntry(newItem);
            return result.Adapt<List<TimeEntryDTO>>();
        }

        public async Task<List<TimeEntryDTO>> DeleteTimeEntry(int id)
        {
            var result = await _repository.DeleteTimeEntry(id);
            if(result is null)
            {
                return null;
            }
            return result.Adapt<List<TimeEntryDTO>>();  
        }

        public async Task<List<TimeEntryDTO>> GetAllTimeEntries()
        {
            var result = await _repository.GetAllTimeEntries();
            return result.Adapt<List<TimeEntryDTO>>();
        }

        public async Task<TimeEntryDTO> GetTimeEntry(int id)
        {
            var result = await _repository.GetTimeEntry(id);
            return result.Adapt<TimeEntryDTO>();
        }

        public async Task<List<TimeEntryDTO>> UpdateTimeEntry(int id, TimeEntryUpdateRequest request)
        {
            var itemToUpdate = request.Adapt<TimeEntry>();
            var result = await _repository.UpdateTimeEntry(id, itemToUpdate);
            if(result is null)
            {
                return null;
            }
            return result.Adapt<List<TimeEntryDTO>>();
        }
    }
}
