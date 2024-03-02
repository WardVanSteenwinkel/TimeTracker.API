using TimeTracker.Domain.Dto.Request;
using TimeTracker.Domain.Dto.Response;
using TimeTracker.Domain.entities;

namespace TimeTracker.API.Services
{
    public interface ITimeEntryService
    {
        Task<List<TimeEntryDTO>> GetAllTimeEntries();
        Task<List<TimeEntryDTO>> CreateTimeEntry(TimeEntryCreateRequest timeEntry);
        Task<List<TimeEntryDTO>> UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry);
        Task<List<TimeEntryDTO>> DeleteTimeEntry(int id);
        Task<TimeEntryDTO> GetTimeEntry(int id);
    }
}
