using Leave_Management.Contracts;
using Leave_Management.Data;
using Microsoft.EntityFrameworkCore;
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

        public bool CheckAllocation(int leavetypeid, string employeeid)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .Where(q => q.EmployeeId == employeeid && q.LeaveTypeId == leavetypeid && q.Period == period)
                .Any();
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
            var leaveAllocations = _db.LeaveAllocations
                .Include(q => q.LeaveType)
                .ToList();
            return leaveAllocations;
           // throw new NotImplementedException();
        }

        public LeaveAllocation FindById(int id)
        {
            var leaveAllocation = _db.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Employee)
                .FirstOrDefault(q => q.Id == id);
            return leaveAllocation;
            //throw new NotImplementedException();
        }

        public ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string employeeid)
        {
            var period = DateTime.Now.Year;

            return FindAll()
                .Where(q => q.EmployeeId == employeeid && q.Period == period)
                .ToList();
        }

        public LeaveAllocation GetLeaveAllocationsByEmployeeAndType(string employeeid, int leavetypeid)
        {
            var period = DateTime.Now.Year;

            return FindAll()
                .FirstOrDefault(q => q.EmployeeId == employeeid && q.Period == period && q.LeaveTypeId == leavetypeid);
        }

        public bool isExists(int id)
        {
            var exists = _db.LeaveAllocations.Any(q => q.Id == id);
            return exists;
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
