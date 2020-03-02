using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class WorkersContext:DbContext
    {
        public WorkersContext(DbContextOptions<WorkersContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<WorkerInfo> WorkersList { get; set; }
    }
}
