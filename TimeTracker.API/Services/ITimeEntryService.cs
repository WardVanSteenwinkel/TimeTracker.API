using TimeTracker.Domain.Dto.Request;
using TimeTracker.Domain.Dto.Response;
using TimeTracker.Domain.entities;

namespace TimeTracker.API.Services
{
    public interface ITimeEntryService
    {
        List<TimeEntryDTO> GetAllTimeEntries();
        Task<List<TimeEntryDTO>> CreateTimeEntry(TimeEntryCreateRequest timeEntry);
        List<TimeEntryDTO> UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry);
        List<TimeEntryDTO> DeleteTimeEntry(int id);
        TimeEntryDTO GetTimeEntry(int id);
    }
}
