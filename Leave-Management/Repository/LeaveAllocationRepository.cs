using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {

        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            //save
            return Save();
            //throw new NotImplementedException();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            //save
            return Save();
            //throw new NotImplementedException();
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            var leaveAllocations = _db.LeaveAllocations.ToList();
            return leaveAllocations;
           // throw new NotImplementedException();
        }

        public LeaveAllocation FindById(int id)
        {
            var leaveAllocation = _db.LeaveAllocations.Find(id);
            return leaveAllocation;
            //throw new NotImplementedException();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
            //throw new NotImplementedException();
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            //save
            return Save();
            throw new NotImplementedException();
        }
    }
}
