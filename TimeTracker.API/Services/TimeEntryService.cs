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
        public List<TimeEntryDTO> CreateTimeEntry(TimeEntryCreateRequest request)
        {
            var newItem = request.Adapt<TimeEntry>();
            var result = _repository.CreateTimeEntry(newItem);
            return result.Adapt<List<TimeEntryDTO>>();
        }

        public List<TimeEntryDTO> DeleteTimeEntry(int id)
        {
            var result = _repository.DeleteTimeEntry(id);
            if(result is null)
            {
                return null;
            }
            return result.Adapt<List<TimeEntryDTO>>();  
        }

        public List<TimeEntryDTO> GetAllTimeEntries()
        {
            return _repository.GetAllTimeEntries().Adapt<List<TimeEntryDTO>>();
        }

        public TimeEntryDTO GetTimeEntry(int id)
        {
            return _repository.GetTimeEntry(id).Adapt<TimeEntryDTO>();
        }

        public List<TimeEntryDTO> UpdateTimeEntry(int id, TimeEntryUpdateRequest request)
        {
            var itemToUpdate = request.Adapt<TimeEntry>();
            var result = _repository.UpdateTimeEntry(id, itemToUpdate);
            return result.Adapt<List<TimeEntryDTO>>();
        }
    }
}
