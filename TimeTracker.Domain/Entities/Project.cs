using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Domain.entities;

namespace TimeTracker.Domain.Entities
{
    public class Project 
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
        public bool IsDeleted { get; set; } = false;
        public DateTime DateDeleted { get; set; }

    }
}
