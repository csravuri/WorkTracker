using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkTracker.Models;

namespace WorkTracker.Data
{
    public class WorkTrackerContext : DbContext
    {
        public WorkTrackerContext (DbContextOptions<WorkTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<WorkTracker.Models.WorkItem> WorkItem { get; set; } = default!;
    }
}
