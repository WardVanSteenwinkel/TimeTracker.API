using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TimeTracker.API.Data;
using TimeTracker.Domain.Dto.Request;
using TimeTracker.Domain.Dto.Response;
using TimeTracker.Domain.entities;

namespace TimeTracker.API.Repositories
{
    public class TimeEntryRepository : ITimeEntryRepository
    {
        private readonly DataContext _dbContext;

        public TimeEntryRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry)
        {
            _dbContext.TimeEntries.Add(timeEntry);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.TimeEntries.ToListAsync();
        }

        public async Task<List<TimeEntry>> DeleteTimeEntry(int id)
        {
            var entryToDelete = await _dbContext.TimeEntries.FirstOrDefaultAsync(t => t.Id == id);
            if (entryToDelete == null)
            {
                return null;
            }
            _dbContext.TimeEntries.Remove(entryToDelete);
            await _dbContext.SaveChangesAsync();    
            return await GetAllTimeEntries();
        }

        public async Task<List<TimeEntry>> GetAllTimeEntries()
        {
            return await _dbContext.TimeEntries.ToListAsync();
        }

        public async Task<TimeEntry> GetTimeEntry(int id)
        {
            var entryToGet = await _dbContext.TimeEntries.FirstOrDefaultAsync(t => t.Id == id);
            if (entryToGet == null)
            {
                return null;
            }
            return entryToGet;
        }

        public async Task<List<TimeEntry>> UpdateTimeEntry(int id, TimeEntry timeEntry)
        {
            var entryToUpdate = await _dbContext.TimeEntries.FirstOrDefaultAsync(x => x.Id == id);
            if (entryToUpdate == null)
            {
                return null;
            }
            entryToUpdate.Start = timeEntry.Start;
            entryToUpdate.End = timeEntry.End;
            entryToUpdate.Project = timeEntry.Project;
            entryToUpdate.DateUpdated = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return await GetAllTimeEntries();
        }
    }
}
