using investment_management_system.Contracts;
using investment_management_system.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace investment_management_system.Repository
{
    //Inheriting from the particular repository
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            //Constuctor initialised, first step for dependancy injection
            _db = db;
        }

        public ICollection<LeaveType> FindAll()
        {
            var leaveTypes = _db.LeaveTypes.ToList();
            return leaveTypes;
        }

        public LeaveType FindById(int id)
        {
            var leaveType = _db.LeaveTypes.Find(id);
            return leaveType;
        }

        public bool Create(LeaveType entity)
        {
             _db.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            // Will return num of records changed
            var changes = _db.SaveChanges();
            return changes > 0;

        }

        public bool isExists(int id)
        {
            // If no arguments are passed it will check whether any records exist within the object.
            // The lambda variable will embody the objects within the collection
            // Boolean check there are any objects within the specified collection that contains an Id property with a value equal to the id parameter
            var isExists = _db.LeaveTypes.Any(q => q.Id == id);
            return isExists;
        }
    }
}
