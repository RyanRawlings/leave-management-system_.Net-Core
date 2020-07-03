using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using investment_management_system.Models;

namespace investment_management_system.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Also need other tables
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveHistory> LeaveHistories { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<investment_management_system.Models.LeaveTypeVM> DetailsLeaveTypeVM { get; set; }
    }
}
