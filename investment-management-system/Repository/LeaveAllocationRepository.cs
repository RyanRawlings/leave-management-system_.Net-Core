using investment_management_system.Contracts;
using investment_management_system.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace investment_management_system.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            //Constuctor initialised, first step for dependancy injection
            _db = db;
        }
        public ICollection<LeaveAllocation> FindAll()
        {
            var leaveAllocations = _db.LeaveAllocations.ToList();
            return leaveAllocations;
        }

        public LeaveAllocation FindById(int id)
        {
            var leaveAllocation = _db.LeaveAllocations.Find(id);
            return leaveAllocation;
        }

        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }

        public bool isExists(int id)
        {
            // If no arguments are passed it will check whether any records exist within the object.
            // The lambda variable will embody the objects within the collection
            // Boolean check there are any objects within the specified collection that contains an Id property with a value equal to the id parameter
            var isExists = _db.LeaveAllocations.Any(q => q.Id == id);
            return isExists;
        }
    }
}
