using Leave_Management.Contracts;
using Leave_Management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveRequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveRequest entity)
        {
            _db.LeaveRequests.Add(entity);
            //save
            return Save();
            //throw new NotImplementedException();
        }

        public bool Delete(LeaveRequest entity)
        {
            _db.LeaveRequests.Remove(entity);
            //save
            return Save();
            //throw new NotImplementedException();
        }

        public ICollection<LeaveRequest> FindAll()
        {
            var leaveHistories = _db.LeaveRequests
                .Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .ToList();
            return leaveHistories;
            //throw new NotImplementedException();
        }

        public LeaveRequest FindById(int id)
        {
            var leaveHistory = _db.LeaveRequests
                .Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .FirstOrDefault(q => q.Id == id);
            return leaveHistory;
            // throw new NotImplementedException();
        }

        public ICollection<LeaveRequest> GetLeaveRequestsByEmployee(string employeeid)
        {
            //var leaveRequests = _db.LeaveRequests
            //    .Include(q => q.RequestingEmployee)
            //    .Include(q => q.ApprovedBy)
            //    .Include(q => q.LeaveType)
            //    .Where(q => q.RequestingEmployeeId == employeeid)
            //    .ToList();
            var leaveRequests = FindAll()
                .Where(q => q.RequestingEmployeeId == employeeid)
                .ToList();
            return leaveRequests;
        }

        public bool isExists(int id)
        {
            var exists = _db.LeaveRequests.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
            //throw new NotImplementedException();
        }

        public bool Update(LeaveRequest entity)
        {
            _db.LeaveRequests.Update(entity);
            //save
            return Save();
            //throw new NotImplementedException();
        }
    }
}
