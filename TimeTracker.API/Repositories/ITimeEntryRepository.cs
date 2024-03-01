using TimeTracker.Domain.entities;

namespace TimeTracker.API.Repositories
{
    public interface ITimeEntryRepository
    {
        List<TimeEntry> GetAllTimeEntries();
        Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry);
        List<TimeEntry> UpdateTimeEntry(int id, TimeEntry timeEntry);
        List<TimeEntry> DeleteTimeEntry(int id);
        TimeEntry GetTimeEntry(int id);
    }
}
