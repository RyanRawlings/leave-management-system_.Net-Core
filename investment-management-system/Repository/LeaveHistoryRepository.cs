using investment_management_system.Contracts;
using investment_management_system.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace investment_management_system.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            //Constuctor initialised, first step for dependancy injection
            _db = db;
        }

        public ICollection<LeaveHistory> FindAll()
        {
            var leaveHistories = _db.LeaveHistories.ToList();
            return leaveHistories;
        }
        public LeaveHistory FindById(int id)
        {
            var leaveHistory = _db.LeaveHistories.Find(id);
            return leaveHistory;
        }
        public bool Create(LeaveHistory entity)
        {
            _db.LeaveHistories.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.LeaveHistories.Remove(entity);
            return Save();
        }

        public bool Update(LeaveHistory entity)
        {
            _db.LeaveHistories.Update(entity);
            return Save();
        }
        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool isExists(int id)
        {
            // If no arguments are passed it will check whether any records exist within the object.
            // The lambda variable will embody the objects within the collection
            // Boolean check there are any objects within the specified collection that contains an Id property with a value equal to the id parameter
            var isExists = _db.LeaveHistories.Any(q => q.Id == id);
            return isExists;
        }
    }
}
