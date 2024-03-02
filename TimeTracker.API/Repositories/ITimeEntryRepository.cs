using TimeTracker.Domain.entities;

namespace TimeTracker.API.Repositories
{
    public interface ITimeEntryRepository
    {
        Task<List<TimeEntry>> GetAllTimeEntries();
        Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry);
        Task<List<TimeEntry>> UpdateTimeEntry(int id, TimeEntry timeEntry);
        Task<List<TimeEntry>> DeleteTimeEntry(int id);
        Task<TimeEntry> GetTimeEntry(int id);
    }
}
