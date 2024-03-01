using Microsoft.AspNetCore.Http.HttpResults;
using TimeTracker.Domain.Dto.Request;
using TimeTracker.Domain.Dto.Response;
using TimeTracker.Domain.entities;

namespace TimeTracker.API.Repositories
{
    public class TimeEntryRepository : ITimeEntryRepository
    {
        private static List<TimeEntry> _timeEntries = new List<TimeEntry>
        {
            new TimeEntry
            {
                Id = 1,
                Project = "test",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1)
            }
        };

        public List<TimeEntry> CreateTimeEntry(TimeEntry timeEntry)
        {
            _timeEntries.Add(timeEntry);
            return _timeEntries;
        }

        public List<TimeEntry> DeleteTimeEntry(int id)
        {
            var entryToDelete = _timeEntries.FirstOrDefault(t => t.Id == id);
            if (entryToDelete == null)
            {
                return null;
            }
            _timeEntries.Remove(entryToDelete);
            return _timeEntries;
        }

        public List<TimeEntry> GetAllTimeEntries()
        {
            return _timeEntries;
        }

        public TimeEntry GetTimeEntry(int id)
        {
            var entryToFindIndex = _timeEntries.FindIndex(t => t.Id == id);
            if (_timeEntries[entryToFindIndex] == null)
            {
                return null;
            }
            return _timeEntries[entryToFindIndex];
        }

        public List<TimeEntry> UpdateTimeEntry(int id, TimeEntry timeEntry)
        {
            var entryToUpdateIndex = _timeEntries.FindIndex(t => t.Id == id);
            if (_timeEntries[entryToUpdateIndex] == null)
            {
                return null;
            }
            _timeEntries[entryToUpdateIndex] = timeEntry;
            return _timeEntries;
        }
    }
}
