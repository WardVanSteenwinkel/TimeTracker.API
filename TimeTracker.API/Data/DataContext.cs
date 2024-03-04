using Microsoft.EntityFrameworkCore;
using TimeTracker.Domain.entities;
using TimeTracker.Domain.Entities;

namespace TimeTracker.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<TimeEntry> TimeEntries { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
